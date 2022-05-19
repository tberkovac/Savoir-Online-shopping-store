using System;
using System.Collections.Generic;

namespace SavoirApp.Models
{
    public class Item
    {
        string name;
        string price;
        List<string> availableSizes;
        string idItem;
        string itemDetails;
        int quantity;
        Gender gender;
        string imageURL;
        Brand brand;
        int inStock;
    }
}
