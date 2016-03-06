using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Parallel_Port_Controller
{
    /// <summary>
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : Window
    {

        MainWindow mw;

        public Password()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mw.Close();
        }

        public Password(MainWindow mwx)
        {
            InitializeComponent();
            this.mw = mwx;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pwbox.Password == "surface")
            {
                this.Hide();
                mw.Show();
            }
            else
            {
                MessageBox.Show("Try another guess, maybe?", "Invalid Phrase", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
