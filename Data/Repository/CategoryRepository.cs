using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.interfaces;
using CarShop.Data.Models;

namespace CarShop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
