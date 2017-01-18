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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
namespace Assignment_WPF
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Page
    {
        string[] cartNames; //lambda expression
        string[] cartDesc;
        double[] cartPrice;
        string[] cartDate;
        string[] cartTime;
        string[] cartAddress;
        int[] cartPstlCd;
        public Cart()
        {
            InitializeComponent();
            List_Arrays();
            if (!Json.LoadJson().Any())
            {               //if List<Item> empty
                textBox.Text = String.Empty;
            }
            else {
                for (int i = 0; i < cartNames.Length; i++)
                {
                    textBox.Text += "Name:\t\t" + cartNames[i] + Environment.NewLine;
                    textBox.Text += "Description:\t" + cartDesc[i] + Environment.NewLine;
                    textBox.Text += "Date:\t\t" + cartDate[i] + Environment.NewLine;
                    textBox.Text += "Time:\t\t" + cartTime[i] + Environment.NewLine;
                    textBox.Text += "Address:\t\t" + cartAddress[i] + " " + cartPstlCd[i] + Environment.NewLine;
                    textBox.Text += String.Format("Price:\t\t{0:f2}" + Environment.NewLine, cartPrice[i]);
                    textBox.Text += Environment.NewLine;
                }
            }
            double totalPrice = cartPrice.Sum();

            textTotalPrice.Text = String.Format("{0:f2}", totalPrice);
        }
        private void List_Arrays()
        {
            cartNames = Data.items.Select(crt => crt.Name).ToArray(); //Backup to print in Receipt after cart empty
            cartDesc = Data.items.Select(crt => crt.Desc).ToArray();
            cartPrice = Data.items.Select(crt => crt.Price).ToArray();
            cartDate = Data.items.Select(crt => crt.Date).ToArray();
            cartTime = Data.items.Select(crt => crt.Time).ToArray();
            cartAddress = Data.items.Select(crt => crt.Address).ToArray();
            cartPstlCd = Data.items.Select(crt => crt.PstlCd).ToArray();
        }


        private void Clear_Cart_Click(object sender, RoutedEventArgs e)
        {
            Json.clearJson();
            Item empty = new Item                  //empty list for textBlock.Text arrays to update
            { };
            var currentList = Json.LoadJson();
            currentList.Add(empty);
            NavigationService.Refresh();     //refresh cart page
        }

        private void CheckOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Payment.xaml", UriKind.Relative));
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
