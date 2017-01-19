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

        int _itemId = 0;
        string _itemName = "";

        public Cleaner(int inItemId)
        {
            _itemId = inItemId;
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
        private void Date_SelectedDateChanged(object sender,SelectionChangedEventArgs e)
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
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            Order order = mainWindow._currentOrder;
            BookingSystemManager bookingManager = mainWindow._bookingManager;
            Boolean isAllUserEntryOkay = true;
            if (this.Date.SelectedDate == null)
            {
                MessageBox.Show("You need to specify the reserve date.");
                isAllUserEntryOkay = false;
            }
            if (this.Time.Text == String.Empty)
            {
                MessageBox.Show("You need to specify the time slot.");
                isAllUserEntryOkay = false;
            }
            if (this.rentalOptionComboBoxInput.SelectedItem == null)
            {
                MessageBox.Show("You need to specify the booking option.");
                isAllUserEntryOkay = false;
            }
            if (this.Address.Text == String.Empty)
            {
                MessageBox.Show("You need to specify the cleaning location.");
                isAllUserEntryOkay = false;
            }
            if (this.PstlCd.Text == String.Empty)
            {
                MessageBox.Show("You need to specify the Postal Code.");
                isAllUserEntryOkay = false;
            }
            if (isAllUserEntryOkay == true)
            {
                if (order == null)
                {
                    order = new Order();
                    order.OrderedBy = 2; //Assume that CINDY logon to place this order.
                }
                OrderDetail orderDetail = new OrderDetail();


                orderDetail.RentalId = ((Rental)this.rentalOptionComboBoxInput.SelectedItem).RentalId;
                orderDetail.PickupTimeSlot = this.Time.Text;
                orderDetail.ReserveDate = this.Date.SelectedDate;
                orderDetail.PstlCd = Int32.Parse(this.PstlCd.Text);
                orderDetail.Address = this.Address.Text;
                orderDetail.ItemId = _itemId;
                order.OrderDetails.Add(orderDetail);

                mainWindow._currentOrder = order;
                MessageBox.Show("You have added one reservation into your cart");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Cart());        //navigate to Cart.xaml
        }
    }
}
