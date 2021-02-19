using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public  IDataResult<List<Vehicle>> GetAll(Expression<Func<Vehicle, bool>> filter = null)
        {
            if(DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Vehicle>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(),Messages.VehiclesListed);
        }
       
        [ValidationAspect(typeof(VehicleValidator))]
        public IResult Add(Vehicle vehicle)
        {
            

            _vehicleDal.Add(vehicle);
            return new SuccessResult(Messages.VehicleAdded);


        }

        public IResult Delete(Vehicle vehicle)
        {
            _vehicleDal.Delete(vehicle);
            return new SuccessResult(Messages.VehicleDeleted);


        }

        public IResult Update(Vehicle vehicle)
        {
            _vehicleDal.Update(vehicle);
            return new SuccessResult(Messages.VehicleUpdated);



        }



        public IDataResult<Vehicle> BringById(int id)
        {
            return new SuccessDataResult<Vehicle>(_vehicleDal.Get(v => v.Id == id));

        }

        public IDataResult<List<Vehicle>> GetVehiclesByBrandId(int id)
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(v => v.BrandId == id));
        }

        public IDataResult<List<Vehicle>> GetVehiclesByColorId(int id)
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(v => v.ColorId == id));

        }

        public IDataResult<List<VehicleDetailDto>> GetVehicleDetails()
        {
            return new SuccessDataResult<List<VehicleDetailDto>>(_vehicleDal.GetVehicleDetails());
        }
        public IDataResult<List<Vehicle>> GetByUnitPrice(decimal min,decimal max)
        {
            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(v => v.DailyPrice >= min && v.DailyPrice <= max));
        }
    }
}
