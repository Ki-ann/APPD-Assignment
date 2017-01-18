using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;


namespace Assignment_WPF.Data
{
    public class BookingSystemManager : BaseDataAccess
    {
	   public List<Item> Items { get; set; }
       public List<Rental> Rentals { get; set; }
       public List<object> TimeSlots { get; set; }
       public BookingSystemManager(){
			this.Items = GetItems();
            this.Rentals = GetRentals();
           // this.TimeSlots = PrepareTimeSlots();
       }//end of constructor
   
       public List<Item> GetItems()
        {
            List<Item> itemList = new List<Item>();
            Item oneItem = null;

            List<DbParameter> parameterList = new List<DbParameter>();
            string sql = "SELECT ItemId, ItemName FROM Item";
            using (DbDataReader dataReader = base.GetDataReader(sql, parameterList, CommandType.Text))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        oneItem = new Item();
                        oneItem.ItemId = (int)dataReader["ItemId"];
                        oneItem.ItemName = (string)dataReader["ItemName"];
                        itemList.Add(oneItem);
                    }
                }
            }
            return itemList;
        }//End of GetItems
        public List<Rental> GetRentals()
        {
            List<Rental> rentalList = new List<Rental>();
            Rental oneRental = null;

            List<DbParameter> parameterList = new List<DbParameter>();
            string sql = "SELECT RentalId, RentalType,RentalPrice, ItemId FROM Rental";
            using (DbDataReader dataReader = base.GetDataReader(sql, parameterList, CommandType.Text))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        oneRental = new Rental();
                        oneRental.RentalId = (int)dataReader["RentalId"];
                        oneRental.RentalType = (string)dataReader["RentalType"];
                        oneRental.RentalPrice = (decimal) dataReader["RentalPrice"];
                        oneRental.ItemId = (int)dataReader["ItemId"];
                        rentalList.Add(oneRental);
                    }
                }
            }
            return rentalList;
        }//End of GetRentals
        //public List<object> PrepareTimeSlots()
        //{
        //    //The logic does not read from database.
        //    //The logic aims to build a List which is usable by the ComboBox input later
        //    //to display to the user to select when to come and pickup the item they reserved.
        //    List<object> timeSlotList = new List<object>();
        //    object timeSlot = new { TimeSlotName = "10:00 AM", TimeSlotValue = "10:00" };
        //    timeSlotList.Add(timeSlot);
        //    timeSlot = new { TimeSlotName = "12:00 PM", TimeSlotValue = "12:00" };
        //    timeSlotList.Add(timeSlot);
        //    timeSlot = new { TimeSlotName = "3:00 PM", TimeSlotValue = "15:00" };
        //    timeSlotList.Add(timeSlot);
        //    return timeSlotList;
        //}//End of PrepareTimeSlots

        public Boolean SaveOrderAndOrderDetails(Order inOrder)
        {
            List<DbParameter> parameterList = new List<DbParameter>();
        
            
            //Assuming a user (CINDY) logon and placed the order
            parameterList.Add(base.GetParameter("inUserId",inOrder.OrderedBy ));

            string sql = "INSERT INTO [ORDER] (OrderedBy) VALUES (@inUserId);SELECT @@IDENTITY;";
            int newOrderIdValue =  Int32.Parse(base.ExecuteScalar(sql, parameterList).ToString());
            sql = "INSERT INTO OrderDetail (OrderId,RentalId,Itemid,ReserveDate,PickUpTimeSlot,Address,PstlCd) VALUES (@inOrderId,@inRentalId,@inItemId,@inReserveDate,@inPickupTimeSlot,@inAddress,@inPostalCode)";
            foreach (var orderDetail in inOrder.OrderDetails)
            {
                parameterList.Clear();
                parameterList.Add(base.GetParameter("@inOrderId", newOrderIdValue));
                parameterList.Add(base.GetParameter("@inRentalId", orderDetail.RentalId));
                parameterList.Add(base.GetParameter("@inItemId", orderDetail.ItemId));
                parameterList.Add(base.GetParameter("@inReserveDate", orderDetail.ReserveDate));
                parameterList.Add(base.GetParameter("@inPickupTimeSlot", orderDetail.PickupTimeSlot));
                parameterList.Add(base.GetParameter("@inAddress", orderDetail.Address));
                parameterList.Add(base.GetParameter("@inPostalCode", orderDetail.PstlCd));
                base.ExecuteScalar(sql, parameterList);
            }
            return true;
        }//End of SaveOrderAndOrderDetails


    }//End of BookingSystemManager class
    }//End of namespace
