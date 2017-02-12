
using Assignment_WPF.Data;
using Assignment_WPF.Pages;
using MaterialDesignColors.WpfExample;
using MaterialDesignColors.WpfExample.Domain;
using MaterialDesignThemes.Wpf;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Assignment_WPF.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Brush theme;
        public BookingManager _bookingManager; //data variable is used to represent the entire file content
        public BookingOrder _currentBooking; //represent cart;
        public User _currentUser;
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _bookingManager = new BookingManager();
            _currentBooking = new BookingOrder();
            Loaded += MainWindow_Loaded;
        }
        public MainWindow(User _inUser)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _bookingManager = new BookingManager();
            _currentBooking = new BookingOrder();
            _currentUser = _inUser;
            userBox.Text = _currentUser.FirstName + " " + _currentUser.LastName;
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow = this;

            frame.NavigationService.Navigate(new Home());   //initial screen
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
        private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
            var MessageDialog = new OptionsDialog
            {};

            await DialogHost.Show(MessageDialog, "RootDialog");
        }
        private async void StatsPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
            var MessageDialog = new StatsDialog
            {

                _inUser = _currentUser
            };

            await DialogHost.Show(MessageDialog, "RootDialog");
        }
        private async void LogoutPopupButton_OnClick(object sender, RoutedEventArgs e)
        {
            var MessageDialog = new LogoutDialog
            { };

            await DialogHost.Show(MessageDialog, "RootDialog");
        }


    }

}
