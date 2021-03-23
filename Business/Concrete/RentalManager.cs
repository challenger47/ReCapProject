using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }



        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckIfVehicleReturned(rental.VehicleId));
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalSucceed);

        }



        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetAvailableVehicles(Rental rental)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.DeliveryDate !=null));
        }

        public IDataResult<Rental> BringById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.VehicleId==id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

      

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        public IResult CheckIfVehicleReturned(int vehicleId)
        {
           Rental result = this.BringById(vehicleId).Data;
            if (result != null)
            {
                if (result.DeliveryDate == null || result.DeliveryDate>DateTime.Now )
                {
                    return new ErrorResult(Messages.NotAvailable);
                }
                return new SuccessResult();
            }
            return new SuccessResult();
        }
    }
}
