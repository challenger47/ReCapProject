using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        IDataResult<List<Vehicle>> GetAll(Expression<Func<Vehicle, bool>> filter = null);
      
        IDataResult<List<Vehicle>> GetVehiclesByColorId(int id);
        IDataResult<List<Vehicle>> GetVehiclesByBrandId(int id);
        IDataResult<List<Vehicle>>GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<VehicleDetailDto>> GetVehicleDetailsByVehicleId(int vehicleId);
        IDataResult<List<VehicleDetailDto>> GetVehicleDetailsByBrandId(int brandId);
        IDataResult<List<VehicleDetailDto>> GetVehicleDetailsByColorId(int colorId);

        IResult Add(Vehicle vehicle);
        IResult Delete(Vehicle vehicle);
        IResult Update(Vehicle vehicle);
        IDataResult<Vehicle> BringById(int id);
        IDataResult<List<VehicleDetailDto>> GetVehicleDetails();
        IResult AddTransactionalTest(Vehicle vehicle);
    

    }
}
