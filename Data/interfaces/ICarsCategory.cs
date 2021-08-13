using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Models;

namespace CarShop.Data.interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }

    }
}
