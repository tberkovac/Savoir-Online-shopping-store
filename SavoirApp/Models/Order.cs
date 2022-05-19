using System;
using System.Collections.Generic;

namespace Savoir.Models
{
    public class Order
    {
        List<Item> chosenItems;
        double totalPrice;
        string idOrder;
        string idUser;
        PayingOptions payingOption;
        Status status;
    }
}
