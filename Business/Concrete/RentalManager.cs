using Business.Abstract;
using Business.Constants;
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

        public IResult IsAvailable(int id)
        {

            var result = _rentalDal.GetRentalDetails(v => v.VehicleId == id && v.DeliveryDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.NotAvailable);
            }
            return new SuccessResult(Messages.RentalSucceed);



        }


        public IResult Add(Rental entity)
        {
            Rental result = this.GetById(entity.VehicleId).Data;
            if(result!=null)
            {
                if (result.DeliveryDate==null)
                {
                    return new ErrorResult();
                }
              
            }
            _rentalDal.Add(entity);
            return new SuccessResult();

        }

        //public IResult Add(Rental rental)
        //{
        //    var result = IsAvailable(rental.VehicleId);
        //    if (!result.Success)
        //    {
        //        return new ErrorResult(result.Message);
        //    }
        //    _rentalDal.Add(rental);
        //    return new SuccessResult(result.Message);

        //}

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

        public IDataResult<Rental> GetById(int id)
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
      
    }
}
