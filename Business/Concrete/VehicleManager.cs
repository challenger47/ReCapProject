﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Caching.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        IBrandService _brandService;
        public VehicleManager(IVehicleDal vehicleDal, IBrandService brandService)
        {
            _vehicleDal = vehicleDal;
            _brandService = brandService;
        }
        [CacheAspect]
        
        public  IDataResult<List<Vehicle>> GetAll(Expression<Func<Vehicle, bool>> filter = null)
        {
           // if(DateTime.Now.Hour==22) örnek iş kuralı
            //{
                //return new ErrorDataResult<List<Vehicle>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Vehicle>>(_vehicleDal.GetAll(),Messages.VehiclesListed);
        }
       
        [ValidationAspect(typeof(VehicleValidator))]
        [SecuredOperation("vehicle.add,admin")]
        [CacheRemoveAspect("IVehicleService.Get")]
        [CacheRemoveAspect("IVehicleService.GetAll")]
        public IResult Add(Vehicle vehicle)
        {
            IResult result = BusinessRules.Run(CheckIfTheSameVehicleCountExceeded(vehicle.VehicleName),CheckIfTheSameBrandCountExceeded());//Eklenecek her yeni kuralın aşağıda metodunu yazıp burda virgülle ayırıp çagırıyoruz
            if (result!=null)
            {
                return result;

            }
            _vehicleDal.Add(vehicle);
            return new SuccessResult(Messages.VehicleAdded);


        }

        public IResult Delete(Vehicle vehicle)
        {
            _vehicleDal.Delete(vehicle);
            return new SuccessResult(Messages.VehicleDeleted);


        }
        [CacheRemoveAspect("IVehicleService.Get")]
        [CacheRemoveAspect("IVehicleService.GetAll")]
        [ValidationAspect(typeof(VehicleValidator))]
        public IResult Update(Vehicle vehicle)
        {
            _vehicleDal.Update(vehicle);
            return new SuccessResult(Messages.VehicleUpdated);



        }


        [CacheAspect]
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


        //İş kuralları
        private IResult CheckIfTheSameVehicleCountExceeded(string vehicleName)
        {
            var result = _vehicleDal.GetAll(p => p.VehicleName == vehicleName).Count;
            if (result>5)
            {

                return new ErrorResult(Messages.TheSameVehicleCountError);

            }
            return new SuccessResult(Messages.VehicleAdded);
        }
        private IResult CheckIfTheSameBrandCountExceeded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count >3)
            {

                return new ErrorResult(Messages.TheSameBrandCountError);

            }
            return new SuccessResult(Messages.VehicleAdded);
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Vehicle vehicle)
        {
            Add(vehicle);
            if (vehicle.DailyPrice<120)
            {
                return new ErrorResult();

            }
            Add(vehicle);
            return null;
        }

        public IDataResult<List<VehicleDetailDto>> GetVehicleDetailsByVehicleId(int vehicleId)
        {
            return new SuccessDataResult<List<VehicleDetailDto>>(_vehicleDal.GetVehicleDetails(v => v.Id == vehicleId));
        }

        public IDataResult<List<VehicleDetailDto>> GetVehicleDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<VehicleDetailDto>>(_vehicleDal.GetVehicleDetails(v => v.BrandId == brandId));
        }

        public IDataResult<List<VehicleDetailDto>> GetVehicleDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<VehicleDetailDto>>(_vehicleDal.GetVehicleDetails(v => v.ColorId == colorId));
        }
    }
}
