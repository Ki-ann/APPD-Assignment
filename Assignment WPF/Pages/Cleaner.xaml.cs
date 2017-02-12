using Assignment_WPF.Data;
using Assignment_WPF.Windows;
using Microsoft.EntityFrameworkCore;
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
            if(Int32.Parse(TimeIn.Text.Substring(0, 2))>=Int32.Parse(TimeOut.Text.Substring(0, 2)))
            {
                MessageBox.Show("Time Start cannot be before or same time as Time End.");
                isAllUserEntryOkay = false;
            }
            if (isAllUserEntryOkay == true)
            {
                Item i = (Item)this.rentalOptionComboBoxInput.SelectedItem;

                Booking order = new Booking();
                order.UserId = mainWindow._currentUser.UserId;
                order.ItemId = i.ItemId;
                order.BookingDateTime = DateTime.Now;
                order.ReservedDate = Date.SelectedDate;
                order.TimeSlotIn = TimeIn.Text;
                order.TimeSlotOut = TimeOut.Text;
                order.ReservedAddress = Address.Text;
                order.ReservedPostal = PstlCd.Text;
                if (isAvailable(order))
                {
                    bookingOrder.BookingList.Add(order);
                    mainWindow._currentBooking = bookingOrder;
                    MessageBox.Show("You have added one reservation into your cart");
                }
                else
                {
                    MessageBox.Show("Sorry the timeslot you have chosen is not available");
                }


            }
            //user has a cartId when logged in,
            //Add values to CartItems with cartId

            //Cart has a list of CartItems
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CartPage());        //navigate to Cart.xaml
        }
        public bool isAvailable(Booking order)
        {
            BookingOrder listChecker = new BookingOrder();
            using (var context = new AppContext())
            {
                listChecker.BookingList = context.Booking.FromSql("SELECT * FROM dbo.Booking").ToList();
            }
            foreach (Booking book in listChecker.BookingList)
            {
                if (book.ReservedDate == order.ReservedDate)
                {
                    int bookIn = Int32.Parse(book.TimeSlotIn.Substring(0, 2));
                    int bookOut = Int32.Parse(book.TimeSlotOut.Substring(0, 2));
                    int orderIn = Int32.Parse(order.TimeSlotIn.Substring(0, 2));
                    int orderOut = Int32.Parse(order.TimeSlotOut.Substring(0, 2));
                    if (orderIn >= bookIn && orderIn <= bookOut)
                    {

                        if (orderOut >= bookIn && orderOut <= bookOut)
                        {
                            return false;
                        }
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

