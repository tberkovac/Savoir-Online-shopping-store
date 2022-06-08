using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace SavoirApp.Models
{
    public class User : IdentityUser
    {
        public double MoneySpent { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }

        [ForeignKey("Wishlist")]
        public int FKWishlistId { get; set; }
        public Wishlist Wishlist { get; set; }

        public String slika { get; set; }

        public User()
        {
        }
    }
}
