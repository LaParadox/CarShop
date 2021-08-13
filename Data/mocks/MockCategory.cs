using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.interfaces;
using CarShop.Data.Models;

namespace CarShop.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get { return new List<Category> { new Category { categoryName = "Electric Cars",desc = "Modern type of transport"},
            new Category{ categoryName = "Regular Cars",desc = "Cars with the petrol engine"} }; }

        }
    }
}
