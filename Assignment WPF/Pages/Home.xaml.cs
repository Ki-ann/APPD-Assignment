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

namespace Assignment_WPF
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            using(var context = new AppContext())
            {
                textBlock.Text = String.Empty;
                foreach(var item in context.Item)
                {
                    textBlock.Text += item.ItemName;
                }
            }
        }

        private void btnStore2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Store());
           NavigationService.Navigate(new Uri("/Pages/Store.xaml", UriKind.Relative));

        }
    }
}
