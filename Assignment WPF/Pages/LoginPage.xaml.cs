using Assignment_WPF.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

            if (usr.Text != string.Empty && pass.Password != string.Empty)
            {
                if (allUsers.Where(c => c.EmailAdd == usr.Text).Any())
                {
                    if (allUsers.Where(c => c.Password == pass.Password).Any())
                    {
                        User u = allUsers.Where(c => c.EmailAdd == usr.Text).FirstOrDefault();
                        MessageBox.Show(string.Format("Welcome {0}!", u.FirstName + " " + u.LastName));
                        LoginWindow mainWindow = (LoginWindow)Application.Current.MainWindow;
                        Application.Current.MainWindow = new MainWindow(u);
                        Application.Current.MainWindow.Show();
                        mainWindow.Close();
                        return;
                    }
                    else { MessageBox.Show("Password is incorrect!"); return; }
                }
                else { MessageBox.Show("Email Address does not exist!"); return; }
            }
            else { MessageBox.Show("Both fields must be filled"); return; }
        }



        private void btnrgst_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());           //navigate to Home.xaml
        }
    }
}
