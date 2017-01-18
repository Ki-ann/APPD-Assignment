using Assignment_WPF.Data;
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

        public static int _itemId = 0;
        string _itemName = "";

        public Cleaner()
        {
            //Set reference to the MainWindow instance
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            //Set reference to the _currentOrder which belongs to the MainWindow instance
            Order order = mainWindow._currentOrder;
            InitializeComponent();
            BookingSystemManager bookingManager = mainWindow._bookingManager;
            List<Rental> rentalOptionListForComboBox = bookingManager.Rentals.Where(input => input.ItemId == _itemId).ToList();
            this.rentalOptionComboBoxInput.ItemsSource = rentalOptionListForComboBox;
            _itemName = bookingManager.Items
                .Where(input => input.ItemId == _itemId)
                .Single()
                .ItemName;
            this.itemNameTextBlock.Text = _itemName;
        }
            
            

            
            
                private void Date_SelectedDateChanged(object sender,
   SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {

            }
            else
            {

            }
        }
        private void btnAddtoCrt_Click(object sender, RoutedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Cart.xaml", UriKind.Relative));          //navigate to Cart.xaml
        }

        

    }
}
