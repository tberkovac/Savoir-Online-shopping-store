using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public class Deliverer
    {
        [Key]
        public int ID { get; set; }
        public List<Order> Orders { get; set; }
        public Order CurrentOrder { get; set; }

        public Deliverer()
        {
        }
    }
}
