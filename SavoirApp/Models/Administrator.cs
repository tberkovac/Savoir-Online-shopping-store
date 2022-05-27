using System;
using System.ComponentModel.DataAnnotations;

namespace SavoirApp.Models
{
    public class Administrator : Person
    {
        [Key]
        public int Id { get; set; }

        public Administrator()
        {
        }
    }
}
