using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows;

namespace Parallel_Port_Controller
{
    /// <summary>
    /// PortAccess Class
    /// Class for controlling parallel port
    /// 
    /// Author: John Aldrin Plata
    /// Date Started: 7/08/2015
    /// Last Documented: 7/12/2015
    /// NOTE: Actual tests weren't made yet
    /// </summary>
    class PortAccess
    {
        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(int adress, int value);

        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern char Read(int address);
    
        public int address;

        private bool connected = false;
        public bool isConnected 
        {
            get
            {
                return connected;
            }
        }

        /// <summary>
        /// Connect to the parallel port using the address provided
        /// </summary>
        /// <param name="address">parallel port address WHERE it will connect</param>
        public void Connect(int address)
        {
            try
            {
                this.address = address;
            }
            catch (Exception e)
            {
                connected = false;
                MessageBox.Show(e.Message);
            }

            connected = true;
        }

        /// <summary>
        /// Reset the port by sending 0 data
        /// </summary>
        public void Reset_Port()
        {
            Send_Port(0);
        }

        /// <summary>
        /// Turn on all port by sending 255 (equivalent byte value)
        /// </summary>
        public void Test_Port()
        {
            Send_Port(255);
        }

        /// <summary>
        /// Sends the data to port
        /// </summary>
        /// <param name="data">data to transmit</param>
        public void Send_Port(int data)
        {
            Output(address, data);
        }

        public int getInput()
        {
            return Read(address);
        }

        /// <summary>
        /// A little animation to test connection
        /// </summary>
        public void Blink()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i == 5)
                    Test_Port();
                if (i == 10)
                    Reset_Port();
            }
        }
    }
}
