using CarShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Car> favCars { get; set; }
    }
}
