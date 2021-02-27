
using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {

        static void Main(string[] args)
        {
            
            VehicleManager vehicleManager = new VehicleManager(new EfVehicleDal(),new BrandManager(new EfBrandDal()));
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            //Console.WriteLine("Araç Listesinin İlk Hali ");
            //VehicleList(vehicleManager);
            //userManager.Add(new User { FirstName = "Oğuz", LastName = "Bayburtlu", EMail = "dsdddaadda", Password = "password" });
            //customerManager.Add(new Customer { UserId = 3, CompanyName = "Nasa" });
            //Console.WriteLine("Müşteri Listesi");
            //UserList(userManager);
            //BrandTest(brandManager);
            //ColorTest(colorManager);
            RentalTest(rentalManager);
          

            Console.ReadLine();
        }

        private static void RentalTest(RentalManager rentalManager)
        {
            var result = rentalManager.GetRentalDetails();
            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.VehicleName + " " + rental.BrandName + " " + rental.CustomerName + " " + rental.UserName + " " + rental.DailyPrice + " " + rental.RentDate + " " + rental.DeliveryDate);

                }
            }

            rentalManager.Add(new Rental { CustomerId = 2, VehicleId = 3, RentDate = Convert.ToDateTime("2021.02.10") });
        }

        private static void ColorTest(ColorManager colorManager)
        {
            colorManager.Delete(new Color { Id = 1013 });
            colorManager.Add(new Color { Name = "Turkuaz" });
            colorManager.BringById(3);
            colorManager.Update(new Color { Id = 6, Name = "Mat Siyah" });
            var result = colorManager.GetAll();
            if (result.Success == true)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.Name);

                }
            }
        }

        private static void BrandTest(BrandManager brandManager)
        {
            brandManager.Delete(new Brand { Id = 1025 });
            brandManager.Add(new Brand { BrandName = "Nissan" });
            brandManager.BringById(2);
            brandManager.Update(new Brand { Id = 7, BrandName = "Citroen" });



            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);


                }
            }
        }

        private static void VehicleList(VehicleManager vehicleManager)
        {
            var result = vehicleManager.GetVehicleDetails();
            if (result.Success == true)
            {


                foreach (var vehicle in result.Data)
                {
                    Console.WriteLine(vehicle.VehicleName + " " + vehicle.BrandName + " " + vehicle.Color + " " + vehicle.DailyPrice);

                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void UserList(UserManager userManager)
        {
            var result = userManager.GetAll();
            if(result.Success==true)
            {
                foreach (var user  in result.Data )
                {
                    Console.WriteLine(user.FirstName + " " + user.LastName);

                }
            }
        }

    } 
}
