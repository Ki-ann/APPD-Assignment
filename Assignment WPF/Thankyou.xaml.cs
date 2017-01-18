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
        public static string[] BackNames;
        public static string[] BackDesc;
        public static double[] BackPrice;
        public static string[] BackDate;
        public static string[] BackTime;
        public static string[] BackAddress;
        public static int[] BackPstlCd;
        public static string[] FName;
        public static string[] LName;

        public Thankyou()
        {
            InitializeComponent();
            backup_Arrays();
            Json.clearJson();
            Item empty = new Item                  //empty list for textBlock.Text arrays to update
            { };
            var currentList = Json.LoadJson();
            currentList.Add(empty);
        }

        private void backup_Arrays()
        {
            BackNames = Data.items.Select(crt => crt.Name).ToArray(); //Backup to print in Receipt after cart empty
            BackDesc = Data.items.Select(crt => crt.Desc).ToArray();
            BackPrice = Data.items.Select(crt => crt.Price).ToArray();
            BackDate = Data.items.Select(crt => crt.Date).ToArray();
            BackTime = Data.items.Select(crt => crt.Time).ToArray();
            BackAddress = Data.items.Select(crt => crt.Address).ToArray();
            BackPstlCd = Data.items.Select(crt => crt.PstlCd).ToArray();
            FName = BillInfo.BInf.Select(b => b.Firstname).ToArray();
            LName = BillInfo.BInf.Select(b => b.Lastname).ToArray();
        }
        private void btn_receipt_Click(object sender, RoutedEventArgs e)
        {
            Receipt win2 = new Receipt();
            win2.Show();
        }
    }
}
