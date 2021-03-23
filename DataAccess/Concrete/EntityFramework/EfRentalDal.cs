using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {



        public List<RentalDetailDto>GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join vehicle in context.Vehicles
                             on rental.VehicleId equals vehicle.Id
                             join brand in context.Brands
                             on vehicle.BrandId equals brand.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id

                             join user in context.Users
                             on customer.UserId equals user.Id //çoklu joinlerde tam isim vermen daha iyi olur
                             select new RentalDetailDto
                             {
                                 Id = rental.Id,
                                 VehicleId = vehicle.Id,
                                 CustomerId = customer.Id,
                                 VehicleName = vehicle.VehicleName,
                                 BrandName=brand.BrandName,
                                 CustomerName = customer.CompanyName,
                                 UserName = $"{ user.FirstName }  { user.LastName }",
                                 DailyPrice=vehicle.DailyPrice,
                                 RentDate = rental.RentDate,
                                 DeliveryDate = rental.DeliveryDate
                             };
                var x = result.ToList();
                return result.ToList();
            }
        }




    }
}
