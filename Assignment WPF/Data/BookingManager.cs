using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment_WPF.Data.EFModels;

namespace Assignment_WPF.Data
{
    public class BookingManager
    {
        public List<Item> Items { get; set; }
        public List<object> TimeSlots { get; set; }

        public BookingManager()
        {
            this.Items = GetItems();
        }

        public List<Item> GetItems()
        {
            List<Item> itemList = new List<Item>();

            using (var context = new AppContext())
            {
                itemList = context.Item.FromSql("SELECT * FROM dbo.Item").ToList();
                return itemList;
            }
        }

        
}
}
