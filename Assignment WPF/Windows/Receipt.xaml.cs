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

namespace Assignment_WPF
{
    /// <summary>
    /// Interaction logic for Receipt.xaml
    /// </summary>
    public partial class Receipt : Window
    {
        
        
        public Receipt(decimal totalPrice,string description)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            bgBox.Background = MainWindow.theme;
            textBox.Text += description;

            textBox.Text += "---------------------------------------------------" + Environment.NewLine;
            textBox.Text += String.Format("Total Price: ${0:f2}" + Environment.NewLine, totalPrice);
            textBox.Text += "---------------------------------------------------" + Environment.NewLine;

            textBox.Text += "Date Of Transaction: " + DateTime.Now.ToString("dd/MM/yyyy") + Environment.NewLine;
            textBox.Text += "Time Of Transaction: " + DateTime.Now.ToString("h:mm:ss tt") + Environment.NewLine;


        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
