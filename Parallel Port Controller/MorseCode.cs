using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Port_Controller
{
    /// <summary>
    /// MorseCode Class
    /// Class for morse code to letter and vice versa conversion
    /// 
    /// Author: John Aldrin Plata
    /// Date Started: 7/08/2015
    /// Last Documented: 7/12/2015
    /// NOTE: Actual tests weren't made yet
    /// </summary>
    class MorseCode
    {

        /// <summary>
        /// Convert from character to equivalent morse code
        /// </summary>
        /// <param name="letter">single character to be converted</param>
        /// <returns>converted morse code</returns>
        public string letterToMorse(string letter)
        {
            string morse = "";

            switch(letter) {
                case "A":
                    morse = ".-";
                    break;
                case "B":
                    morse = "-...";
                    break;
                case "C":
                    morse = "-.-.";
                    break;
                case "D":
                    morse = "-..";
                    break;
                case "E":
                    morse = ".";
                    break;
                case "F":
                    morse = "..-.";
                    break;
                case "G":
                    morse = "--.";
                    break;
                case "H":
                    morse = "....";
                    break;
                case "I":
                    morse = "..";
                    break;
                case "J":
                    morse = ".---";
                    break;
                case "K":
                    morse = "-.-";
                    break;
                case "L":
                    morse = ".-..";
                    break;
                case "M":
                    morse = "--";
                    break;
                case "N":
                    morse = "-.";
                    break;
                case "O":
                    morse = "---";
                    break;
                case "P":
                    morse = ".--.";
                    break;
                case "Q":
                    morse = "--.-";
                    break;
                case "R":
                    morse = ".-.";
                    break;
                case "S":
                    morse = "...";
                    break;
                case "T":
                    morse = "-";
                    break;
                case "U":
                    morse = "..-";
                    break;
                case "V":
                    morse = "...-";
                    break;
                case "W":
                    morse = ".--";
                    break;
                case "X":
                    morse = "-..-";
                    break;
                case "Y":
                    morse = "-.--";
                    break;
                case "Z":
                    morse = "--..";
                    break;
                case "0":
                    morse = "-----";
                    break;
                case "1":
                    morse = ".----";
                    break;
                case "2":
                    morse = "..---";
                    break;
                case "3":
                    morse = "...--";
                    break;
                case "4":
                    morse = "....-";
                    break;
                case "5":
                    morse = ".....";
                    break;
                case "6":
                    morse = "_....";
                    break;
                case "7":
                    morse = "__...";
                    break;
                case "8":
                    morse = "___..";
                    break;
                case "9":
                    morse = "----.";
                    break;
            }

            return morse;
        }

        /// <summary>
        /// Convert morse code to letter
        /// </summary>
        /// <param name="morse">morse code to be converted back to letter</param>
        /// <returns>equivalent letter of the morse code</returns>
        public string morseToLetter(string morse)
        {
            //TODO: finish this thing

            return "false";
        }
    }
}
