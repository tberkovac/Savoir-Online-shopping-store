using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavoirApp.Models
{
    public class Wishlist
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("VIPUser")]
        public int IDVIPUser { get; set; }
        public VIPUser VIPUser { get; set; }

        [ForeignKey("Item")]
        public int IDItem { get; set; }
        public Item Item { get; set; }

        public Wishlist()
        {
        }
    }
}
