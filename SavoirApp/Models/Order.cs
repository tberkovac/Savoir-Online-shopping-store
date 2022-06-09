using SavoirApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SavoirApp.Models
{
    public class Order
    {
        private readonly ApplicationDbContext _context;
        [Key]
        public int ID { get; set; }
        public double TotalPrice { get; set; }

        [ForeignKey("User")]
        public string IDUser { get; set; }
        public User User { get; set; }
        
        [EnumDataType(typeof(PayingOptions))]
        public PayingOptions PayingOption { get; set; }

        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }

        public Order(string userid)
        {
            this.IDUser = userid;
        }
        public Order()
        {
        }
        public void izracunajCijenu()
        {
            var cijena = 0;
            //U SLJEDECOJ LINIJI (39) SE BACA IZUZETAK !!! NullReferenceException: Object reference not set to an instance of an object.
            var items = _context.OrderItems.Where(x => x.IDOrder == ID).ToList();
          
             foreach(var par in items)
             {
                 var aritakl = _context.Items.First(x => x.ID == par.IDItem);
                 cijena += int.Parse(aritakl.Price);

             }

            TotalPrice = cijena;
        }
    }
}
