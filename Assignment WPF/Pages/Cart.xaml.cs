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
using Newtonsoft.Json;
using Assignment_WPF.Data;

namespace Assignment_WPF
{
    /// <summary>
    /// Interaction logic for Cart.xaml
    /// </summary>
    public partial class Cart : Page
    {
        //string[] cartNames; //lambda expression
        //string[] cartDesc;
        //double[] cartPrice;
        //string[] cartDate;
        //string[] cartTime;
        //string[] cartAddress;
        //int[] cartPstlCd;
        decimal totalPrice = 0;
        public Cart()
        {
            
            
            //Set reference to the MainWindow instance
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            //Set reference to the _currentOrder which belongs to the MainWindow instance
            Order order = mainWindow._currentOrder;
            BookingSystemManager bookingManager = mainWindow._bookingManager;
            InitializeComponent();
            textTotalPrice.Text = "0";
            if (order == null)
            {
                TextBlock messageTextBlock = new TextBlock();
                messageTextBlock.Text = "You have not selected any items yet.";
                this.contentStackPanel.Children.Add(messageTextBlock);
            }
            else
            {

                foreach (var orderDetail in order.OrderDetails)
                {
                    string itemName = bookingManager.Items
                                   .Where(input => input.ItemId == orderDetail.ItemId)
                                   .Single()
                                   .ItemName;
                    Rental rental = bookingManager.Rentals
                        .Where(input => input.RentalId == orderDetail.RentalId)
                        .Single();
                    TextBlock itemReservationDescriptionTextBlock = new TextBlock();
                    string description = "Item Option : " + itemName + "\n";
                    description += "Booking Option : " + rental.RentalType + "\n";
                    description += "Booked Timeslot : " + orderDetail.PickupTimeSlot + "\n";
                    description += "Address : " + orderDetail.Address + " " + orderDetail.PstlCd + "\n";
                    description += "Price : $" + rental.RentalPrice + "\n";
                    itemReservationDescriptionTextBlock.Text = description;
                    itemReservationDescriptionTextBlock.Margin = new Thickness(4, 4, 4, 4);
                    this.contentStackPanel.Children.Add(itemReservationDescriptionTextBlock);
                    totalPrice += rental.RentalPrice;
                }//End of foreach
                textTotalPrice.Text = totalPrice.ToString();
            }
        }

        private void Clear_Cart_Click(object sender, RoutedEventArgs e)
        {
            //Set reference to the MainWindow instance
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            contentStackPanel.Children.Clear();
            textTotalPrice.Text = "0";
            mainWindow._bookingManager = new BookingSystemManager();
            mainWindow._currentOrder = new Order();
            NavigationService.Refresh();
        }

        private void CheckOut_Click(object sender, RoutedEventArgs e)
        {
            //Set reference to the MainWindow instance
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            //Set reference to the _currentOrder which belongs to the MainWindow instance
            Order order = mainWindow._currentOrder;
            BookingSystemManager bookingManager = mainWindow._bookingManager;
            bookingManager.SaveOrderAndOrderDetails(order);
            MessageBox.Show("You have successfully booked our cleaning services.");
            NavigationService.Navigate(new Thankyou(totalPrice,contentStackPanel));
        }

    }
}
