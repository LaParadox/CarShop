using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.interfaces;
using CarShop.ViewModels;
using CarShop.Data.Models;

namespace CarShop.Controllers
{
    public class CarsController:Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;
        public CarsController(IAllCars iAllCars,ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Electric Cars")).OrderBy(i=>i.id);
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Regular Cars")).OrderBy(i => i.id);
                }
                currCategory = _category;
            }
            var carObj = new CarListViewModel
            {
                allCars = cars, 
                currCategory = currCategory
            };
            ViewBag.Title = "Cars Shop";
            return View(carObj);
        }
    }
}
