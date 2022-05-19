using System;
using System.Collections.Generic;

namespace SavoirApp.Models
{
    public class Deliverer
    {
        string id;
        List<Order> orders;
        Order currentOrder;
    }
}
