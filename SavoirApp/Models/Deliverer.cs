using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SavoirApp.Models
{
    public class Deliverer
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Orders")]
        public int IDCurrentOrder { get; set; }
        public Order CurrentOrder { get; set; }

        public Deliverer()
        {
        }
    }
}
