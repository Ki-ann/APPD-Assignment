
using Assignment_WPF.Data;
using Assignment_WPF.Pages;
using MahApps.Metro.Controls;
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
        public BookingManager _bookingManager; //data variable is used to represent the entire file content
        public BookingOrder _currentBooking; //represent cart;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _bookingManager = new BookingManager();
            _currentBooking = new BookingOrder();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;
            frame.NavigationService.Navigate(new Home());   //initial screen
            cmbColors.ItemsSource = typeof(Brushes).GetProperties();
        }//end of MainWindow_loaded
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Home());           //navigate to Home.xaml
        }

        private void btnStore_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Store());          //navigate to Store.xaml
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new CartPage());
        }
        private void cmbColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            theme = (Brush)(cmbColors.SelectedItem as PropertyInfo).GetValue(null, null);
            bgBox.Background = theme;
        }
    }

}
