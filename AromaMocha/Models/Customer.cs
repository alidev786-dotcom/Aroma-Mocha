using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
 


namespace AromaMocha.Models
{
    
    [Table("Customers")]
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage="Email is invalid!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is invalid!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage ="Address is invalid!")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Contact is invalid!")]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }
        
        
        //public  CafeTable cafeTable   { get; set; }
    }
}