using Assignment_WPF.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static Assignment_WPF.Data.EFModels;

namespace Assignment_WPF.Pages
{
    /// <summary>
    /// Interaction logic for Cleaner.xaml
    /// </summary>

    public partial class Cleaner : Page
    {

        int _cleanerId = 0;

        public Cleaner(int inCleanerId)
        {
            _cleanerId = inCleanerId;

            InitializeComponent();
            this.Loaded += Page_Loaded;

        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            BookingManager bookingManager = mainWindow._bookingManager;

            using (var context = new AppContext())
            {                        //set Chosen category name
                var inCleaningName = (from cat in context.Category
                                      where cat.CategoryId == _cleanerId
                                      select cat.CategoryName).Single();
                itemNameTextBlock.Text = inCleaningName;
            }
            var itemOptionListForComboBox = bookingManager.Items.Where(c => c.CategoryId == _cleanerId).ToList();
            rentalOptionComboBoxInput.ItemsSource = itemOptionListForComboBox;
            await Task.Delay(15);                       //delay needed to allow ItemSource to initialize, and SelectedIndex to succeed.
            rentalOptionComboBoxInput.SelectedIndex = 0;

        }
        private void btnAddtoCrt_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            BookingOrder bookingOrder = mainWindow._currentBooking;
            //
            //ValidationCheck
            //
            Boolean isAllUserEntryOkay = true;
            if (this.Date.SelectedDate == null)
            {
                MessageBox.Show("You need to specify the reserve date.");
                isAllUserEntryOkay = false;
            }
            if (this.TimeIn.Text == String.Empty)
            {
                MessageBox.Show("You need to specify the time slot in.");
                isAllUserEntryOkay = false;
            }
            if (this.TimeOut.Text == String.Empty)
            {
                MessageBox.Show("You need to specify the time slot out.");
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
                Item i = (Item)this.rentalOptionComboBoxInput.SelectedItem;

                Booking order = new Booking();
                order.UserId = 1;
                order.ItemId = i.ItemId;
                order.BookingDateTime = DateTime.Now;
                order.ReservedDate = Date.SelectedDate;
                order.TimeSlotIn = TimeIn.Text;
                order.TimeSlotOut = TimeOut.Text;
                order.ReservedAddress = Address.Text;
                order.ReservedPostal = PstlCd.Text;
                bookingOrder.BookingList.Add(order);
                mainWindow._currentBooking = bookingOrder;
                MessageBox.Show("You have added one reservation into your cart");

            }
            //user has a cartId when logged in,
            //Add values to CartItems with cartId

            //Cart has a list of CartItems
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage());        //navigate to Cart.xaml
        }
    }
}

