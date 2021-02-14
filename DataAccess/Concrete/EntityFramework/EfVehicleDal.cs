using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfVehicleDal : EfEntityRepositoryBase<Vehicle, RentACarContext>, IVehicleDal
    {
        public List<VehicleDetailDto> GetVehicleDetails(Expression<Func<Vehicle, bool>> filter = null)
        {
            using (RentACarContext context=new RentACarContext())
            {
                var result = from v in filter == null ? context.Vehicles : context.Vehicles.Where(filter)
                             join b in context.Brands
                             on v.BrandId equals b.Id
                             join c in context.Colors
                             on v.ColorId equals c.Id
                             select new VehicleDetailDto {Id=v.Id,VehicleName=v.VehicleName, BrandName=b.BrandName,Color=c.Name,DailyPrice=v.DailyPrice };
                return result.ToList(); // VAR RESULT BİR DONGU DONDURUYOR
            }
        }
    }
}
