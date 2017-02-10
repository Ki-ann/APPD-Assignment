using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_WPF
{

    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public decimal ItemPrice { get; set; }
    }

    public class BookingOrder
    {
        public BookingOrder()
        {
            this.BookingList = new List<Booking>();
        }
        public List<Booking> BookingList { get; set; }
    }
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public DateTime BookingDateTime { get; set; }
        [Required]
        public string TimeSlotIn { get; set; }
        [Required]
        public string TimeSlotOut { get; set; }
        [Required]
        public DateTime? ReservedDate { get; set; }
        [Required]
        public string ReservedAddress { get; set; }
        [Required]
        public string ReservedPostal { get; set; }
    }


    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string EmailAdd { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostCd { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Password { get; set; }

    }

    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string CardNo { get; set; }
        [Required]
        public int CVC { get; set; }
        [Required]
        public DateTime? ExpDate { get; set; }
    }
}
