using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public  Car car { get; set; }
        public decimal price { get; set; }

        public string ShopCartId { get; set; }
    }
}
