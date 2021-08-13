using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Models;

namespace CarShop.ViewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }
        public string currCategory { get; set; }
    }
}
