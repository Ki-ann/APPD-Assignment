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

namespace Assignment_WPF
{
    /// <summary>
    /// Interaction logic for Thankyou.xaml
    /// </summary>
    public partial class Thankyou : Page
    {
        public static decimal _totalPrice = 0;
        public static string _description;
        public StackPanel _Panel;
        public Thankyou(decimal price, StackPanel stackpanel)
        {
            InitializeComponent();
            _totalPrice = price;
            _Panel = stackpanel;
            foreach(object child in _Panel.Children)
            {
                TextBlock item = (TextBlock)child;
                _description += item.Text + "\n"; 
            }
        }

       
        private void btn_receipt_Click(object sender, RoutedEventArgs e)
        {
            Receipt win2 = new Receipt(_totalPrice, _description);
            win2.Show();
        }
    }
}
