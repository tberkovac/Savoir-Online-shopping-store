using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavoirApp.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public double TotalPrice { get; set; }

        [ForeignKey("User")]
        public string IDUser { get; set; }
        public User User { get; set; }
        
        [EnumDataType(typeof(PayingOptions))]
        public PayingOptions PayingOption { get; set; }

        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        public Order()
        {
        }

     
    }
}
