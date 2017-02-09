using System.Windows;
using System.Windows.Controls;

namespace Assignment_WPF.Pages
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
            foreach(StackPanel child in _Panel.Children)
            {
                foreach (TextBlock tb in (StackPanel)(_Panel.Children))
                {
                    StackPanel item = (TextBlock)child;
                    _description += item.Text + "\n";
                }
            }
        }

       
        private void btn_receipt_Click(object sender, RoutedEventArgs e)
        {
            Receipt win2 = new Receipt(_totalPrice, _description);
            win2.Show();
        }
    }
}
