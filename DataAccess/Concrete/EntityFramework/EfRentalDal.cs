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



        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join v in context.Vehicles
                             on r.VehicleId equals v.Id
                             join b in context.Brands
                             on v.BrandId equals b.Id
                             join c in context.Customers
                             on r.CustomerId equals c.Id
                             
                             join u in context.Users
                             on c.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 VehicleName = v.VehicleName,
                                 BrandName=b.BrandName,
                                 CustomerName = c.CompanyName,
                                 UserName = u.FirstName + " " + u.LastName,
                                 DailyPrice=v.DailyPrice,
                                 RentDate = r.RentDate,
                                 DeliveryDate = r.DeliveryDate
                             };
                return result.ToList();
            }
        }




    }
}
