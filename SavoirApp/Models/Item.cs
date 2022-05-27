using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public class Item
    {
        [Key]
        public int IdItem { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public List<string> AvailableSizes { get; set; }
        public string ItemDetails { get; set; }
        public int Quantity { get; set; }
        public Gender Gender { get; set; }
        public string ImageURL { get ; set ; }
        public Brand Brand { get; set; }
        public int InStock { get; set; }

        public Item()
        {
        }
    }

}
