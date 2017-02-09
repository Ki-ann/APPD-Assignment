using Assignment_WPF.Pages;
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

namespace Assignment_WPF.Windows
{
    /// <summary>
    /// Interaction logic for LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        public LoginWin()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            frame.NavigationService.Navigate(new LoginPage());   //initial screen
            //cmbColors.ItemsSource = typeof(Brushes).GetProperties();

        }
        
    }
}
