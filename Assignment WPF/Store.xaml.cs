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
using Newtonsoft.Json.Linq;

namespace Assignment_WPF
{
    /// <summary>
    /// Interaction logic for Store.xaml
    /// </summary>
    public partial class Store : Page
    {
        public Store()
        {
            InitializeComponent();
        }

        private void btncleaner_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Cleaner.xaml", UriKind.Relative));          //navigate to Cleaner.xaml
        }

        private void btnpkgclean_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("PkgCleaning.xaml", UriKind.Relative));          //navigate to PkgCleaning.xaml
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("Cart.xaml", UriKind.Relative));          //navigate to Cart.xaml
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}




