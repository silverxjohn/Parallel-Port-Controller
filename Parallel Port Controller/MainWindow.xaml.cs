using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;
using System.ComponentModel;

namespace Parallel_Port_Controller
{
    /// <summary>
    /// MainWindow Class
    /// Class to manage user's interactions
    /// 
    /// Author: John Aldrin Plata
    /// Date Started: 7/08/2015
    /// Last Documented: 7/12/2015
    /// NOTE: Actual tests weren't made yet
    /// </summary>
    public partial class MainWindow : Window
    {
        Ellipse[] f;
        MiddleCon midcon;
        BackgroundWorker bworker;
        
        bool usePassword = false;

        string morsecode = "";
        int portnumber = 8;

        public MainWindow()
        {
            InitializeComponent();

            f = new Ellipse[8];
            f[0] = f1; f[1] = f2; f[2] = f3; f[3] = f4;
            f[4] = f5; f[5] = f6; f[6] = f7; f[7] = f8;


            bworker = new BackgroundWorker();
            bworker.DoWork += Bworker_DoWork;
            bworker.RunWorkerCompleted += Bworker_RunWorkerCompleted;
            bworker.Disposed += Bworker_Disposed;

            if (usePassword)
            {
                this.Hide();
                Password pwo = new Password(this);
                pwo.ShowDialog();
            }
            midcon = new MiddleCon(f);
        }

        private void Bworker_Disposed(object sender, EventArgs e)
        {
            bworker.CancelAsync();
        }

        private void Bworker_DoWork(object sender, DoWorkEventArgs e)
        {
            int length = morsecode.Length;
            int count = 0;
            foreach (char x in morsecode)
            {
                if (x == '.')
                {
                    count++;
                    midcon.PortSend(1);
                    Thread.Sleep(1000);
                    midcon.PortSend(0);
                    Thread.Sleep(1000);
                }
                else if (x == '-')
                {
                    count++;
                    midcon.PortSend(1);
                    Thread.Sleep(2000);
                    midcon.PortSend(0);
                    Thread.Sleep(1000);
                }
                else if (x == ' ')
                {
                    count++;
                    midcon.PortSend(1);
                    Thread.Sleep(1000);
                    midcon.PortSend(0);
                    Thread.Sleep(1000);
                }

                if (count == length)
                {
                    bworker.Dispose();
                }
            }
        }

        private void Bworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bworker.RunWorkerAsync();
        }

        public bool isPortC
        {
            get
            {
                if (isUsingC.IsChecked == true)
                    return true;
                else
                    return false;
            }
        }
        
        /// <summary>
        /// Convert letter to morse code and put it in Textbox txt_morse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            midcon.insertLetter(sender.ToString().Last() + "", txt_morse);
        }

        /// <summary>
        /// Invoke reset method from MiddleCon and if not successful, shows an error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            if (!midcon.PortReset())
                MessageBox.Show("Please find and enter the port address", "No connection was made",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Invoke test method from MiddleCon and if not successful, shows an error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Test_Click(object sender, RoutedEventArgs e)
        {
            if (!midcon.PortTest())
                MessageBox.Show("Please find and enter the port address", "No connection was made",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Invoke connect method from MiddleCon and if not successful, shows an error message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, RoutedEventArgs e)
        {
            midcon.PortConnect(txt_address.Text);
        }

        /// <summary>
        /// Invoke ShowOutput method from MiddleCon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Send_Click(object sender, RoutedEventArgs e)
        {
            if (txt_morse.Text != "" && PortBox.Text != "")
            {
                morsecode = txt_morse.Text;
                portnumber = System.Convert.ToInt32(PortBox.Text);
                bworker.RunWorkerAsync();
            }
        }

        private void btn_Help_Click(object sender, RoutedEventArgs e)
        {
            string read = midcon.CheckUpdateInput();

            if (isPortC)
            {
                MessageBox.Show(midcon.InvertBinary(read));
            }
            else
            {
                MessageBox.Show(read);
            }
        }

        #region "GRID"
        private void g1_Click(object sender, RoutedEventArgs e)
        {
            midcon.GridHelper(0);
        }

        private void g2_click(object sender, MouseButtonEventArgs e)
        {
            midcon.GridHelper(1);
        }

        private void g3_click(object sender, MouseButtonEventArgs e)
        {
            midcon.GridHelper(2);
        }

        private void g4_click(object sender, MouseButtonEventArgs e)
        {
            midcon.GridHelper(3);
        }

        private void g5_click(object sender, MouseButtonEventArgs e)
        {
            midcon.GridHelper(4);
        }

        private void g6_click(object sender, MouseButtonEventArgs e)
        {
            midcon.GridHelper(5);
        }

        private void g7_click(object sender, MouseButtonEventArgs e)
        {
            midcon.GridHelper(6);
        }

        private void g8_click(object sender, MouseButtonEventArgs e)
        {
            midcon.GridHelper(7);
        }
        #endregion
    }
}
