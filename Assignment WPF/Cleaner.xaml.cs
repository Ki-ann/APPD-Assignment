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

namespace Assignment_WPF
{
    /// <summary>
    /// Interaction logic for Cleaner.xaml
    /// </summary>
    public partial class Cleaner : Page
    {
        public Cleaner()
        {
            InitializeComponent();
        }

        private void btnAddtoCrt_Click(object sender, RoutedEventArgs e)
        {
            bool isempty = false;

            try
            {
                Item tryd = new Item
                {
                    Name = "Cleaner Booking",
                    Desc = "Booking of cleaner",
                    Date = Date.Text,
                    Time = Time.Text,
                    Address = Address.Text,
                    PstlCd = int.Parse(PstlCd.Text),
                    Price = 12.00
                };
            }
            catch (InvalidOperationException)
            {
                isempty = true;
                ErrorDialog win2 = new ErrorDialog();
                win2.Show();

            }
            catch (System.FormatException)
            {
                isempty = true;
                ErrorDialog win2 = new ErrorDialog();
                win2.Show();

            }
            if (isempty == false)
            {
                Item customer = new Item
                {
                    Name = "Cleaner Booking",
                    Desc = "Booking of cleaner",
                    Date = Date.Text,
                    Time = Time.Text,
                    Address = Address.Text,
                    PstlCd = int.Parse(PstlCd.Text),
                    Price = 12.00
                };
                var currentList = Json.LoadJson();
                currentList.Add(customer);
                Json.serialize(currentList);
                ConfirmationDialog win = new ConfirmationDialog();
                win.Show();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Cart.xaml", UriKind.Relative));          //navigate to Cart.xaml
        }
    }
}
