
using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = " Honda" });
            VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal());
            Console.WriteLine("Araç Listesinin İlk Hali ");
            foreach (var vehicle in vehicleManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", vehicle.Id, vehicle.Id, vehicle.ColorId, vehicle.DailyPrice, vehicle.Description);

            }

            vehicleManager.Add(new Vehicle { BrandId = 7, ColorId = 4, DailyPrice = 199.90m, Description = "Otomatik", ModelYear = new DateTime(2021) });

            
            



            vehicleManager.Delete(new Vehicle() { Id = 12 });
           
            foreach (var vehicle in vehicleManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}",vehicle.Id,vehicle.BrandId,vehicle.ColorId,vehicle.DailyPrice,vehicle.Description);

            }
            
            
               
            
            vehicleManager.Update(new Vehicle() { Id = 7, BrandId = 4, ColorId = 1, DailyPrice = 300, ModelYear = new DateTime(2021),Description="Otomatik Dizel 6 vites" });
            Console.WriteLine("Yapılan Güncellemeden sonra ki liste");
            foreach (var vehicle in vehicleManager.GetAll())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", vehicle.Id, vehicle.BrandId, vehicle.ColorId,vehicle.DailyPrice, vehicle.Description);

            }

            Console.WriteLine("id ye göre gelen araç");
            Vehicle vById= vehicleManager.BringById(7);
            Console.WriteLine("{0} {1} {2} {3} {4}",vById.Id,vById.ColorId,vById.BrandId,vById.DailyPrice,vById.Description);
            Console.WriteLine("Markaya göre araç listesi");
            foreach (var vehicle in vehicleManager.GetVehiclesByBrandId(4))
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", vehicle.Id, vehicle.BrandId, vehicle.ColorId, vehicle.DailyPrice, vehicle.Description);
            }
            Console.WriteLine("Renge göre araç listesi");
            foreach (var vehicle in vehicleManager.GetVehiclesByColorId(1))
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", vehicle.Id, vehicle.BrandId, vehicle.ColorId, vehicle.DailyPrice, vehicle.Description);
            }
            Console.ReadLine();
        }

        
}
}
