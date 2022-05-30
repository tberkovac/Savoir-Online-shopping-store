using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavoirApp.Models
{
    public class VIPUserOrders
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("VIPUsers")]
        public int IDVIPUser { get; set; }
        public VIPUser VIPUser { get; set; }

        [ForeignKey("Orders")]
        public int IDOrder { get; set; }
        public Order Order { get; set; }

        public VIPUserOrders()
        {
        }
    }
}
