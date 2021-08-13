using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShop.Data.Models;

namespace CarShop.Data.interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> getFavCars { get; }
        Car getObjectCar(int carId);
    }
}
