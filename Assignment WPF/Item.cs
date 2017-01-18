using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Assignment_WPF
{

    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Desc { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Address { get; set; }
        public int PstlCd { get; set; }

    }

    public class Data
    {
        public static List<Item> items = new List<Item>();
    }

    public class Payment
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CardType { get; set; }
        public string CardNo { get; set; }
        public string ExpMon { get; set; }
        public string ExpYr { get; set; }
        public string SecCd { get; set; }
        public string BillAdd { get; set; }
        public string PostCd { get; set; }
        public string PhoneNo { get; set; }

    }
    public class BillInfo
    {
        public static List<Payment> BInf = new List<Payment>();
    }
}
