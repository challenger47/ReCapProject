
using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            
           
            VehicleManager vehicleManager = new VehicleManager(new InMemoryVehicleDal());
            Console.WriteLine("Araç Listesinin İlk Hali ");
            foreach (var vehicle in vehicleManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", vehicle.Id, vehicle.BrandId, vehicle.ColorId, vehicle.DailyPrice, vehicle.Description);

            }

            vehicleManager.Add(new Vehicle { Id = 7, BrandId = 4, ColorId = 2, DailyPrice = 200, Description = "Otomatik", ModelYear = new DateTime(2021) });

            vehicleManager.Delete(new Vehicle() { Id = 5 });
           
            foreach (var vehicle in vehicleManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",vehicle.Id,vehicle.BrandId,vehicle.ColorId,vehicle.DailyPrice,vehicle.Description);

            }
            foreach (var vehicle in vehicleManager.BringById(7))
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5}", "İd ye göre Getirilen Araç bilgileri ", vehicle.Id, vehicle.BrandId, vehicle.ColorId,vehicle.DailyPrice, vehicle.Description);
            }
            vehicleManager.Update(new Vehicle() { Id = 3, BrandId = 4, ColorId = 1, DailyPrice = 300, ModelYear = new DateTime(2021),Description="6 Vites Otomatik" });
            Console.WriteLine("Yapılan Güncellemeden sonra ki liste");
            foreach (var vehicle in vehicleManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", vehicle.Id, vehicle.BrandId, vehicle.ColorId,vehicle.DailyPrice, vehicle.Description);

            }
            Console.ReadLine();
        }

        
}
}
