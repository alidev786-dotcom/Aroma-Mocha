using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AromaMocha.Models
{
    [Table("CafeTables")]
    public class CafeTable
    {
        public int ID { get; set; }
        public int TableNumber { get; set; }
        public int TableCapacity { get; set; }
        public bool isBooked { get; set; }
        public string Status { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? CustomerID { get; set; }
        public Customer customer { get; set; }
    }
}