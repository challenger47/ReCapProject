using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        List<Vehicle> GetAll();
        List<Vehicle> GetVehiclesByColorId(int id);
        List<Vehicle> GetVehiclesByBrandId(int id);
        void Add(Vehicle vehicle);
        void Delete(Vehicle vehicle);
        void Update(Vehicle vehicle);
        Vehicle BringById(int id);
        //List<Vehicle> BringById(int id); çalışır ama yanlış yöntem

    }
}
