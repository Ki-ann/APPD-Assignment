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
            textBox.Text += description + Environment.NewLine;
            //textBox.Text += "Customer Name: " + Thankyou.FName[0] + " " + Thankyou.LName[0] + Environment.NewLine + Environment.NewLine;
            //textBox.Text += "---------------------------------------------------" + Environment.NewLine;
            //textBox.Text += "Service Booked: " + Environment.NewLine + Environment.NewLine;
            //for (int i = 0; i < Thankyou.BackNames.Length; i++)
            //{
            //    textBox.Text += Thankyou.BackNames[i] + Environment.NewLine;
            //    textBox.Text += Thankyou.BackDesc[i] + Environment.NewLine;
            //    textBox.Text += "Date:\t" + Thankyou.BackDate[i] + Environment.NewLine;
            //    textBox.Text += "Time:\t" + Thankyou.BackTime[i] + Environment.NewLine;
            //    textBox.Text += String.Format("Price:\t${0:f2}" + Environment.NewLine, Thankyou.BackPrice[i]);
            //    textBox.Text += Environment.NewLine;
            //}

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
