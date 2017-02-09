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
            NavigationService.Navigate(new Home());           //navigate to Home.xaml
        }

        private void btnrgst_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Register());           //navigate to Home.xaml
        }
    }
}
