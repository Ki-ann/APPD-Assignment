using Assignment_WPF.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace MaterialDesignColors.WpfExample.Domain
{
    /// <summary>
    /// Interaction logic for OptionsDialog.xaml
    /// </summary>
    public partial class OptionsDialog : UserControl
    {
        public OptionsDialog()
        {
            InitializeComponent();
            cmbColors.ItemsSource = typeof(Brushes).GetProperties();
        }
        private void cmbColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.theme = (Brush)(cmbColors.SelectedItem as PropertyInfo).GetValue(null, null);
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).bgBox.Background = MainWindow.theme;
                }
            }
        }
    }
}
