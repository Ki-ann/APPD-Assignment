using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Assignment_WPF
{
    public class Rental
    {
        public int RentalId { get; set; }
        public string RentalType { get; set; }
        public decimal RentalPrice { get; set; }
        public int ItemId { get; set; }
    }
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
    }

    public class Order
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }
        public int OrderId { get; set; }
        public DateTime OrderDateAndTime { get; set; }
        public int OrderedBy { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int RentalId { get; set; }
        public int ItemId { get; set; }
        public DateTime? ReserveDate { get; set; }
        public string PickupTimeSlot { get; set; }
        public string Address { get; set; }
        public int PstlCd { get; set; }


    }
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
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
}
