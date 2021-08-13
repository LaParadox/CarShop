using CarShop.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));
            if(!content.Car.Any())
            {
                content.AddRange(
                     new Car
                     {
                         name = "Tesla Model S",
                         shortDesc = "Car with electric engine",
                         longDesc = "Comfortable noiseless car for city",
                         img = "/img/tesla_model_s_182016.jpg",
                         price = 45000,
                         isFavourite = true,
                         available = true,
                         Category = Categories["Electric Cars"]
                     },
                    new Car
                    {
                        name = "BMW M5 COMPETITION CS",
                        shortDesc = "Family sedan with sporty caracter",
                        longDesc = "Extremely powerfull family sedan that destroys supercars",
                        img = "/img/5ef0702010443d0001bfe242.jpg",
                        price = 180000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Regular Cars"]
                    },
                    new Car
                    {
                        name = "Mercedes-Benz C-class 6.3 AMG",
                        shortDesc = "Sport family car",
                        longDesc = "600 h.p. family beast-sedan",
                        img = "/img/11832310.jpg",
                        price = 160000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Regular Cars"]
                    },
                    new Car
                    {
                        name = "Nissan Leaf",
                        shortDesc = "Electric family car",
                        longDesc = "Compact comfortable electric car to own in a big city",
                        img = "/img/1200px-2018_Nissan_Leaf_Tekna_Front.jpg",
                        price = 18000,
                        isFavourite = false,
                        available = false,
                        Category = Categories["Electric Cars"]
                    }
                    );
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
       public static Dictionary<string,Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                         new Category { categoryName = "Electric Cars",desc = "Modern type of transport"},
                         new Category{ categoryName = "Regular Cars",desc = "Cars with the petrol engine"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el); 
                }
                return category;
            }
        }
    }
}
