using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public List<Vehicle> GetAll()
        {
            return _vehicleDal.GetAll();
        }
       
        public void Add(Vehicle vehicle)
        {
            _vehicleDal.Add(vehicle);
            Console.WriteLine(vehicle.Id+" Id li Araç Eklendi");
        }

        public void Delete(Vehicle vehicle)
        {
            _vehicleDal.Delete(vehicle);
            Console.WriteLine(vehicle.Id + " Id li Araç Silindi");
        }

        public void Update(Vehicle vehicle)
        {
            _vehicleDal.Update(vehicle);
            Console.WriteLine(vehicle.Id + " Id li Araç Bilgileri Güncellendi");
        }

        public List<Vehicle> BringById(int id)
        {
            return _vehicleDal.BringById(id);

        }
    }
}
