using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavoirApp.Models
{
    public class ItemSizes
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Item")]
        public int IDItem { get; set; }
        public Item item { get; set; }

        public string Size { get; set; }
        public ItemSizes()
        {
        }
    }
}
