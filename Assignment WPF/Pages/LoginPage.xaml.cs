using Assignment_WPF.Windows;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;
using static Assignment_WPF.Data.EFModels;

namespace Assignment_WPF.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();

        }
        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {
            List<User> allUsers = new List<User>();
            using (var context = new AppContext())
            {
                allUsers = context.User.ToList();
            }
            foreach (User u in allUsers)
            {
                if (u.EmailAdd == usr.Text && u.Password == pass.Text)
                {
                    MessageBox.Show(string.Format("Welcome {0}!", u.FirstName + " " + u.LastName));
                    LoginWindow mainWindow = (LoginWindow)Application.Current.MainWindow;
                    Application.Current.MainWindow = new MainWindow();
                    Application.Current.MainWindow.Show();
                    mainWindow.Close();
                }else if(u.EmailAdd != usr.Text)
                {
                    MessageBox.Show("Email Address does not exist!");
                }else if(u.EmailAdd == usr.Text && u.Password != pass.Text)
                {
                    MessageBox.Show("Password is incorrect!");
                }
            }


        }

        private void btnrgst_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());           //navigate to Home.xaml
        }
    }
}
