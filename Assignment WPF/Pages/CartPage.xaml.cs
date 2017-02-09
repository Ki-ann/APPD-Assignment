using Assignment_WPF.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static Assignment_WPF.Data.EFModels;

namespace Assignment_WPF.Pages
{
    /// <summary>
    /// Interaction logic for CartPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        public MainWindow mainWindow;
        decimal totalPrice = 0.00M;
        public CartPage()
        {
            //Set reference to the MainWindow instance
            mainWindow = (MainWindow)Application.Current.MainWindow;
            //Set reference to the _currentOrder which belongs to the MainWindow instance
            BookingOrder order = mainWindow._currentBooking;
            BookingManager bookingManager = mainWindow._bookingManager;
            InitializeComponent();
            if (!order.BookingList.Any())           //if empty
            {
                CheckOut.IsEnabled = false;
                TextBlock messageTextBlock = new TextBlock();
                messageTextBlock.Text = "You have not selected anything yet.";
                contentStackPanel.Children.Add(messageTextBlock);
                textTotalPrice.Text = totalPrice.ToString();
            }
            else
            {
                foreach (var booking in order.BookingList)
                {
                    StackPanel sp = new StackPanel();
                    sp.Orientation = Orientation.Horizontal;
                    TextBlock messageTextBlock = new TextBlock()
                    {
                        Width = 300
                    };
                    string itemName = "";
                    decimal itemPrice = 0.00M;
                    using (var context = new AppContext())
                    {
                        itemName = (from item in context.Item
                                    where item.ItemId == booking.ItemId
                                    select item.ItemName).Single();
                        itemPrice = (from item in context.Item
                                     where item.ItemId == booking.ItemId
                                     select item.ItemPrice).Single();
                        totalPrice += itemPrice;
                    }//end of using
                    messageTextBlock.Text += string.Format("Item Option : {0}\n", itemName);
                    messageTextBlock.Text += string.Format("Price : {0}\n", itemPrice);
                    messageTextBlock.Text += string.Format("Booked Date : {0}\n", booking.ReservedDate);
                    messageTextBlock.Text += string.Format("TimeSlot : {0}-{1}\n", booking.TimeSlotIn, booking.TimeSlotOut);
                    messageTextBlock.Text += string.Format("Service Address : {0} {1}\n", booking.ReservedAddress, booking.ReservedPostal);
                    Button btn = new Button()
                    {

                        Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 },
                        Height = 20,
                        Width = 20,
                        Tag = booking
                    };
                    btn.Click += new RoutedEventHandler(Clear_Item);
                    sp.Children.Add(messageTextBlock);
                    sp.Children.Add(btn);
                    this.contentStackPanel.Children.Add(sp);
                }//end of foreach
                textTotalPrice.Text = totalPrice.ToString();
            }//end of else
        }
        private void Clear_Item(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Booking book = (Booking)(btn.Tag);
            var item = this.mainWindow._currentBooking.BookingList.FirstOrDefault(x => x.Equals(btn.Tag));

            using (var context = new AppContext())
            {
                decimal itemPrice = (from i in context.Item
                                     where i.ItemId == book.ItemId
                                     select i.ItemPrice).Single();
                totalPrice = totalPrice - itemPrice;
                textTotalPrice.Text = totalPrice.ToString();
            }

            this.mainWindow._currentBooking.BookingList.Remove(item);

            contentStackPanel.Children.Remove((StackPanel)btn.Parent);
        }
        private void Clear_Cart_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow._currentBooking = new BookingOrder();
            NavigationService.Navigate(new CartPage());
        }

        private void CheckOut_Click(object sender, RoutedEventArgs e)
        {
            BookingOrder order = mainWindow._currentBooking;
            using (var context = new AppContext())
            {
                foreach (Booking b in order.BookingList)
                {
                    context.Booking.Add(b);
                    context.SaveChanges();
                }
            }
            MessageBox.Show("You have successfully booked our cleaning services.");
            this.mainWindow._currentBooking = new BookingOrder();
            NavigationService.Navigate(new Thankyou(totalPrice,contentStackPanel));
        }


    }
}

