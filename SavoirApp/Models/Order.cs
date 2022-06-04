using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public double TotalPrice { get; set; }
        public PayingOptions PayingOption { get; set; }
        public Status Status { get; set; }

        public Order()
        {
        }
    }
}
