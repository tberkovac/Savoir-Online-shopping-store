using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public class Order
    {
        [Key]
        public string ID { get; set; }
        public double TotalPrice { get; set; }
        public string IdUser { get; set; }
        public PayingOptions PayingOption { get; set; }
        public Status Status { get; set; }

        public Order()
        {
        }
    }
}
