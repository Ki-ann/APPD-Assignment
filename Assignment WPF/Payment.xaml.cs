using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : Page
    {
        public Checkout()
        {
            InitializeComponent();
            BillInfo.BInf = new List<Payment>();
        }


        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Cart.xaml", UriKind.Relative));
        }

        private void btn_checkout_Click(object sender, RoutedEventArgs e)
        {
            var customer = new Payment {
                CardType = PaymentOptionBox.Text,
                CardNo = CardNoBox.Text,
                SecCd = SecurityCodeBox.Text,
                ExpMon = Month.Text,
                ExpYr = Year.Text,
                Firstname = FirstName.Text,
                Lastname = LastName.Text,
                BillAdd = BillAdd.Text,
                PostCd = PostalCode.Text,
                PhoneNo = PhoneNo.Text
            };
            BillInfo.BInf.Add(customer);

                NavigationService.Navigate(new Uri("Thankyou.xaml", UriKind.Relative));
        }
    }
}
