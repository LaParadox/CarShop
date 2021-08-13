using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int CarId { get; set; }
        public decimal price { get; set; }
        public virtual Car car { get; set; }
        public virtual Order order { get; set; }
    }
}
