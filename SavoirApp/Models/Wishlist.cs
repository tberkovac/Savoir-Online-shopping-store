using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavoirApp.Models
{
    public class Wishlist
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Users")]
        public int IDUser { get; set; }
        public User User { get; set; }

        [ForeignKey("Items")]
        public int IDItem { get; set; }
        public Item Item { get; set; }

        public Wishlist()
        {
        }
    }
}
