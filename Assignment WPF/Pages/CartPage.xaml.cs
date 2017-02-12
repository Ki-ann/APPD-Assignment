using Assignment_WPF.Data;
using Assignment_WPF.Windows;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
                CheckOut.IsEnabled = false;         //disable checkout button if empty
                TextBlock messageTextBlock = new TextBlock();
                messageTextBlock.Text = "You have not selected anything yet.";
                contentStackPanel.Children.Add(messageTextBlock);
                textTotalPrice.Text = totalPrice.ToString();
            }
            else
            {
                foreach (var booking in order.BookingList)      //create Stackpanels of MessageBlock + ClearButton
                {
                    StackPanel sp = new StackPanel() { Margin = new Thickness { Top = 30, Left = 25 } };
                    sp.Orientation = Orientation.Horizontal;

                    TextBlock messageTextBlock = new TextBlock()
                    {
                        Width = 300
                    };
                    string itemName = "";
                    decimal itemPrice = 0.00M;
                    int quantity = 0;
                    using (var context = new AppContext())
                    {
                        itemName = (from item in context.Item
                                    where item.ItemId == booking.ItemId
                                    select item.ItemName).Single();
                        int bookIn = Int32.Parse(booking.TimeSlotIn.Substring(0, 2));
                        int bookOut = Int32.Parse(booking.TimeSlotOut.Substring(0, 2));
                        quantity = bookOut - bookIn;

                        itemPrice = (from item in context.Item
                                     where item.ItemId == booking.ItemId
                                     select item.ItemPrice).Single() * quantity ;
                        totalPrice += itemPrice;
                    }//end of using
                    messageTextBlock.Text += string.Format("Item Option : {0}\n", itemName);
                    messageTextBlock.Text += string.Format("Price : ${0}\n", itemPrice);
                    messageTextBlock.Text += string.Format("Booked Date : {0}\n", booking.ReservedDate);
                    messageTextBlock.Text += string.Format("TimeSlot : {0}-{1}\n", booking.TimeSlotIn, booking.TimeSlotOut);
                    messageTextBlock.Text += string.Format("Service Address : {0} {1}\n", booking.ReservedAddress, booking.ReservedPostal);
                    Image img = new Image();
                    img.Height = 35;
                    
                    img.Source = new BitmapImage(new Uri(string.Format("pack://application:,,,/{0};component/Data/Images/black_x.png", Path.GetFileNameWithoutExtension(Application.ResourceAssembly.Location))));
                    Button btn = new Button()
                    {
                        Margin = new Thickness { Top = 3, Bottom = 3, Left = 3, Right = 3 },
                        Height = 50,
                        Width = 50,
                        Tag = booking
                    };
                    btn.Content = img;
                    btn.Click += new RoutedEventHandler(Clear_Item);
                    sp.Children.Add(messageTextBlock);
                    sp.Children.Add(btn);
                    Border bd = new Border()
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(0, 0, 0, 1)
                    };

                    bd.Child = (StackPanel)sp;
                    this.contentStackPanel.Children.Add(bd);            //Add Combo to mainStackPanel

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
                int bookIn = Int32.Parse(book.TimeSlotIn.Substring(0, 2));
                int bookOut = Int32.Parse(book.TimeSlotOut.Substring(0, 2));

                totalPrice = totalPrice - itemPrice*(bookOut - bookIn);
                textTotalPrice.Text = totalPrice.ToString();
            }

            this.mainWindow._currentBooking.BookingList.Remove(item);

            contentStackPanel.Children.Remove((Border)((StackPanel)btn.Parent).Parent); //contentStackPanel>(Border>StackPanel>[MessageBleock + button])
            if (contentStackPanel.Children.Count < 1)
            {
                NavigationService.Navigate(new CartPage());
            }
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
                }//end of foreach
            }//end of using
            MessageBox.Show("You have successfully booked our cleaning services.");
            this.mainWindow._currentBooking = new BookingOrder(); //clear BookingList
            NavigationService.Navigate(new Thankyou(totalPrice, contentStackPanel));
        }


    }
}

