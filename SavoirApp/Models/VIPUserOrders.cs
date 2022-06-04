using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavoirApp.Models
{
    public class VIPUserOrders
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Users")]
        public int IDUser { get; set; }
        public User User { get; set; }

        [ForeignKey("Order")]
        public int IDOrder { get; set; }
        public Order Order { get; set; }

        public VIPUserOrders()
        {
        }
    }
}
