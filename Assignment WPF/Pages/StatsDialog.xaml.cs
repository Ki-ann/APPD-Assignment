using Assignment_WPF;
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

namespace MaterialDesignColors.WpfExample.Domain
{
    /// <summary>
    /// Interaction logic for StatsDialog.xaml
    /// </summary>
    public partial class StatsDialog : UserControl
    {
        public User _inUser { get;set;}
        public StatsDialog()
        {
            InitializeComponent();
            this.Loaded += stats_loaded;
        }
        private void stats_loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new AppContext()) {
                int totalbookcount = (from user in context.Booking
                                      where user.UserId == _inUser.UserId
                                      select user.BookingId).Count();
                totalBooked.Text += totalbookcount;
                avgWeek.Text += string.Format("{0:f2}", ((decimal)totalbookcount / 7));
                    }
        }
    }
}
