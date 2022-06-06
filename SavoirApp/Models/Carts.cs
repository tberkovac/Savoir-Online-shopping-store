using System;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public class Carts
    {
        [Key]
        public int Id { get; set; }


        public Carts()
        {
        }
    }
}
