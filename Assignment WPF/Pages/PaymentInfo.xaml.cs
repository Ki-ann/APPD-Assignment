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
using static Assignment_WPF.Data.EFModels;

namespace Assignment_WPF.Pages
{
    /// <summary>
    /// Interaction logic for PaymentInfo.xaml
    /// </summary>
    public partial class PaymentInfo : Page
    {
        int _userId = 0;
        public PaymentInfo(int inUserId)
        {
            _userId = inUserId;
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Payment pay = new Payment()
            {
                UserId = _userId,
                FirstName = frstName.Text,
                LastName = LstName.Text,
                CardNo = CrdNo.Text,
                ExpDate = expDate.SelectedDate,
                CVC = Int32.Parse(CVC.Text)
            };
            using(var context = new AppContext())
            {
                context.Add(pay);
                context.SaveChanges();
                MessageBox.Show("Registration was a Success!");
            }
            NavigationService.Navigate(new LoginPage());
        }
    }
}
