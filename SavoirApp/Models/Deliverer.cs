using System;
using System.Collections.Generic;

namespace Savoir.Models
{
    public class Deliverer
    {
        string id;
        List<Order> orders;
        Order currentOrder;
    }
}
