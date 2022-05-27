using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public class RegisteredUser
    {
        [Key]
        public int ID { get; set; }
        public double MoneySpent { get; set; }
        public List<Order> Orders { get; set; }

        public RegisteredUser()
        {
        }
    }
}
