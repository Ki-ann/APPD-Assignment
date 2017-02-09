using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Assignment_WPF.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnStore2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Store());
           NavigationService.Navigate(new Uri("/Pages/Store.xaml", UriKind.Relative));

        }
    }
}
