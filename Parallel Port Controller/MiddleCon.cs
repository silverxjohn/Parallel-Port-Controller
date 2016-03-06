using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Parallel_Port_Controller
{
    /// <summary>
    /// MiddleCon Class
    /// Middleman class that separates views from controllers
    /// 
    /// Author: John Aldrin Plata
    /// Date Started: 7/08/2015
    /// Last Documented: 7/12/2015
    /// NOTE: Actual tests weren't made yet
    /// </summary>
    class MiddleCon
    {
        PortAccess portAccess;
        MorseCode morseCode;
        


        Ellipse[] f;
        int portnumber = 0;

        /// <summary>
        /// Class Constructor
        /// </summary>
        /// <param name="f">Array of Ellipse</param>
        public MiddleCon(Ellipse[] f)
        {
            this.f = f;

            portAccess = new PortAccess();
            morseCode = new MorseCode();

        }

        /// <summary>
        /// Method responsible for adding the morse code equivalent of letter
        /// </summary>
        /// <param name="letter">character to translate to morse code</param>
        /// <param name="TxtboxMorse">Textbox where the code will be place</param>
        public void insertLetter(string letter, TextBox TxtboxMorse)
        {
            if (TxtboxMorse.Text != "")
            {
                TxtboxMorse.Text += " ";
                TxtboxMorse.Text += morseCode.letterToMorse(letter);
            }
            else
            {
                TxtboxMorse.Text += morseCode.letterToMorse(letter);
            }
        }

        /// <summary>
        /// Verify if address is correct, then connect
        /// </summary>
        /// <param name="address">parallel port address</param>
        public void PortConnect(string address)
        {
            if (address != null && address != "")
                portAccess.Connect(System.Convert.ToInt32(address));
        }

        /// <summary>
        /// Test if the connection was successful
        /// </summary>
        /// <returns>True if the connection is good; otherwise false</returns>
        public bool PortTest()
        {
            if (portAccess.isConnected)
            {
                portAccess.Test_Port();
                
                return true;
            }

            return false;
        }

        /// <summary>
        /// Send a data to parallel port
        /// </summary>
        /// <param name="data">Must be a decimal number. It will be converted into binary as output</param>
        /// <returns>True if the transmission is good; otherwise false</returns>
        public bool PortSend(int data)
        {
            if (portAccess.isConnected)
            {
                portAccess.Send_Port(data);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Send a data only to specific pin in the port
        /// </summary>
        /// <param name="data">1 if you want to turn on the controller</param>
        /// <param name="port">which port number you want to control</param>
        /// <returns>True if the transmission is good; otherwise false</returns>
        public bool PortOnlySend(int data, int port)
        {
            if (portAccess.isConnected)
            {
                switch (port)
                {
                    case 1:
                        if (data == 1)
                        {
                            PortSend(256);
                        }
                            
                        break;
                    case 2:
                        if (data == 1)
                        {
                            PortSend(128);
                        }
                            
                        break;
                    case 3:
                        if (data == 1)
                        {
                            PortSend(32);
                        }
                            
                        break;
                    case 4:
                        if (data == 1)
                        {
                            PortSend(16);
                        }
                            
                        break;
                    case 5:
                        if (data == 1)
                        {
                            PortSend(8);
                        }
                            
                        break;
                    case 6:
                        if (data == 1)
                        {
                            PortSend(4);
                        }
                            
                        break;
                    case 7:
                        if (data == 1)
                        {
                            PortSend(2);
                        }
                        break;
                    case 8:
                        if (data == 1)
                        {
                            PortSend(1);
                        }
                        break;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Reset the port by turning the controllers off
        /// </summary>
        /// <returns>True if resetting was successful; otherwise false</returns>
        public bool PortReset()
        {
            if (portAccess.isConnected) {
                portAccess.Reset_Port();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get the specific port status
        /// </summary>
        /// <param name="ellipse">Port number represented by an ellipse</param>
        /// <returns>True if the port is currently running; otherwise false</returns>
        public bool getLedStatus(Ellipse ellipse)
        {
            if (ellipse.Fill == Brushes.Blue)
                return true;

            return false;
        }

        /// <summary>
        /// Set the ellipse to on/off
        /// </summary>
        /// <param name="ellipse">ellipse to update</param>
        /// <param name="status">true if on; otherwise false</param>
        public void LedController(Ellipse ellipse, bool status)
        {
            if (status)
                ellipse.Fill = Brushes.Blue;
            else
                ellipse.Fill = Brushes.SteelBlue;
        }

        /// <summary>
        /// Get the current Ellipse status and convert it into binary
        /// </summary>
        /// <returns>converted binary in string</returns>
        private string convertToBinary()
        {
            string binary = "";

            for (int i = 0; i < f.Length; i++ )
            {
                if (getLedStatus(f[i]))
                    binary += "1";
                else
                    binary += "0";
            }

            return binary;
        }

        /// <summary>
        /// Update changes
        /// </summary>
        public void makeChanges()
        {
            int binary;
            binary = System.Convert.ToInt32(convertToBinary(), 2);

            portAccess.Send_Port(binary);
        }

        public int updatePort(int dec)
        {
            int binary = 0;

            return binary;
        }

        /// <summary>
        /// Once the grid clicked, this method will invoke and update the ellipse status
        /// </summary>
        /// <param name="place">Port number that has been changed/clicked</param>
        public void GridHelper(int place)
        {
            if (getLedStatus(f[place]))
                LedController(f[place], false);
            else
                LedController(f[place], true);

            makeChanges();
        }

        public string CheckUpdateInput()
        {
            return System.Convert.ToString(portAccess.getInput(), 2);
        }

        public string InvertBinary(string ibyte)
        {
            string invertedBin = "";
            char[] binverted = new char[5];
            int position = 0;

            if (ibyte != "")
            {
                //get all bits into array
                foreach (char bit in ibyte)
                {
                    binverted[position] = bit;
                    position++;
                }

                if (binverted[4] == '0')
                    invertedBin += "1";
                else if (binverted[3] == '1')
                    invertedBin += "0";

                if (binverted[3] == '0')
                    invertedBin += "0";
                else if (binverted[2] == '1')
                    invertedBin += "1";

                if (binverted[2] == '0')
                    invertedBin += "1";
                else
                    invertedBin += "0";

                if (binverted[1] == '1')
                    invertedBin += "0";
                else
                    invertedBin += "1";
                
            }
            else if (ibyte == "1000")
            {
                invertedBin = ibyte;
            }

            return invertedBin;
        }
        


    }
}
