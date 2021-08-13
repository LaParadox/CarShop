using CarShop.Data.interfaces;
using CarShop.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Chekout()
        {
            return View(); 
        }
    }
}
