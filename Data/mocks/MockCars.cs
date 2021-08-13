using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.interfaces;
using CarShop.Data.Models;

namespace CarShop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars {
            get
            {
                return new List<Car> {
                    new Car
                    {
                        name = "Tesla Model S",shortDesc="Car with electric engine",longDesc="Comfortable noiseless car for city",img = "/img/tesla_model_s_182016.jpg",price=45000,isFavourite = true,available=true,Category = _categoryCars.AllCategories.First()
                    },
                    new Car
                    {
                        name ="BMW M5 COMPETITION CS",shortDesc="Family sedan with sporty caracter", longDesc="Extremely powerfull family sedan that destroys supercars",img="/img/5ef0702010443d0001bfe242.jpg",price=180000,isFavourite=true,available=true,Category=_categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        name ="Mercedes-Benz C-class 6.3 AMG",shortDesc="Sport family car", longDesc="600 h.p. family beast-sedan",img="/img/11832310.jpg",price=160000,isFavourite=true,available=true,Category=_categoryCars.AllCategories.Last()
                    },
                    new Car
                    {
                        name ="Nissan Leaf",shortDesc="Electric family car", longDesc="Compact comfortable electric car to own in a big city",img="/img/1200px-2018_Nissan_Leaf_Tekna_Front.jpg",price=18000,isFavourite=false,available=false,Category=_categoryCars.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }
       

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
