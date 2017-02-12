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

            Boolean isAllUserEntryOkay = true;
            if (this.frstname.Text == String.Empty)
            {
                MessageBox.Show("Please input your firstname.");
                isAllUserEntryOkay = false;
            }
            if (this.lstname.Text == String.Empty)
            {
                MessageBox.Show("Please input your lastname.");
                isAllUserEntryOkay = false;
            }
            if (this.pass.Text == String.Empty)
            {
                MessageBox.Show("Please input your password.");
                isAllUserEntryOkay = false;
            }
            if (!IsValidEmail(eml.Text))
            {
                MessageBox.Show("Please input a proper email.");
                isAllUserEntryOkay = false;
            }
            if (this.eml.Text == String.Empty)
            {

                MessageBox.Show("You must input your email.");
                isAllUserEntryOkay = false;
            }
            if (this.phnno.Text == String.Empty)
            {
                MessageBox.Show("Please input your phone number.");
                isAllUserEntryOkay = false;
            }
            if (this.add.Text == String.Empty)
            {
                MessageBox.Show("Please input your address.");
                isAllUserEntryOkay = false;
            }
            if (!IsValidPstlCd(pstlcd.Text))
            {
                MessageBox.Show("Please input a proper postal code!");
                isAllUserEntryOkay = false;
            }
            if (this.pstlcd.Text == String.Empty)
            {
                MessageBox.Show("Please input your postal code.");
                isAllUserEntryOkay = false;
            }
            if (isAllUserEntryOkay == true)
            {
                using (var context = new AppContext())
                {
                    context.User.Add(usr);
                    context.SaveChanges();
                    NavigationService.Navigate(new PaymentInfo(_userId));
                }
            }
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool IsValidPstlCd(string pstlcd)
        {
            if (pstlcd.Length != 6)
            {
                return false;
            }
            else
            {
                int result;
                return Int32.TryParse(pstlcd, out result);
            }
        }


    }
}



