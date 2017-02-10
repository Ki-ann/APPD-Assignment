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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int _userId = 0;
            User usr = new User();
            usr.FirstName = frstname.Text;
            usr.LastName = lstname.Text;
            usr.Password = pass.Text;
            usr.EmailAdd = eml.Text;
            usr.PhoneNo = phnno.Text;
            usr.Address = add.Text;
            usr.PostCd = pstlcd.Text;
            using (var context = new AppContext())
            {
                context.User.Add(usr);
                context.SaveChanges();
                MessageBox.Show("Success");
                _userId = context.User.Last().UserId;
            }
            NavigationService.Navigate(new PaymentInfo(_userId));

        }
    }
}
