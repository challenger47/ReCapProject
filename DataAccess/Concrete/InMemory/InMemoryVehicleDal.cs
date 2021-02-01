using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryVehicleDal : IVehicleDal
    {
        List<Vehicle> _vehicles;
        public InMemoryVehicleDal()
        {
            _vehicles = new List<Vehicle>
            {
                new Vehicle{Id=1, BrandId=2,ColorId=3,ModelYear=new DateTime(2013), DailyPrice=150,Description="Manuel"},
                new Vehicle{Id=2, BrandId=1,ColorId=2,ModelYear=new DateTime(2012), DailyPrice=170,Description="Manuel"},
                new Vehicle{Id=3, BrandId=3,ColorId=1,ModelYear=new DateTime(2015), DailyPrice=100,Description="Manuel"},
                new Vehicle{Id=4, BrandId=4,ColorId=4,ModelYear=new DateTime(2020), DailyPrice=175,Description="Otomatik"},
                new Vehicle{Id=5, BrandId=2,ColorId=1,ModelYear=new DateTime(2018), DailyPrice=130,Description="Manuel"},
                new Vehicle{Id=6, BrandId=4,ColorId=2,ModelYear=new DateTime(2017), DailyPrice=250,Description="Otomatik"},
            };
        }
        public void Add(Vehicle vehicle)
        {
            _vehicles.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            Vehicle vehicleToDelete = _vehicles.SingleOrDefault(v => v.Id == vehicle.Id);
            _vehicles.Remove(vehicleToDelete);
        }

        public List<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public List<Vehicle> BringById(int Id)
        {
           return _vehicles.Where(v => v.Id == Id).ToList();
        }

        public void Update(Vehicle vehicle)
        {
            Vehicle vehicleToUpdate = _vehicles.SingleOrDefault(v => v.Id == vehicle.Id);
            vehicleToUpdate.BrandId = vehicle.BrandId;
            vehicleToUpdate.ColorId = vehicle.ColorId;
            vehicleToUpdate.Description = vehicle.Description;
            vehicleToUpdate.ModelYear = vehicle.ModelYear;
            vehicleToUpdate.DailyPrice = vehicle.DailyPrice;
        }
    }
}
