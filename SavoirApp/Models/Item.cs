﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string ItemDetails { get; set; }
        public int Quantity { get; set; }

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        public string ImageURL { get ; set ; }

        [EnumDataType(typeof(Brand))]
        public Brand Brand { get; set; }
        public int InStock { get; set; }

        public Item()
        {
        }
    }

}
