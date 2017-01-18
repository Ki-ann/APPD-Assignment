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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Brush theme;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Json.LoadJson();
            frame.Source = new Uri("Home.xaml", UriKind.RelativeOrAbsolute);
            cmbColors.ItemsSource = typeof(Brushes).GetProperties();
            //initial screen
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("Home.xaml", UriKind.Relative));           //navigate to Home.xaml
        }

        private void btnStore_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("Store.xaml", UriKind.Relative));          //navigate to Store.xaml
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri("Cart.xaml", UriKind.Relative));           //navigate to Cart.xaml
        }

        private void cmbColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            theme = (Brush)(cmbColors.SelectedItem as PropertyInfo).GetValue(null, null);
            bgBox.Background = theme;
            
        }

    }

}
