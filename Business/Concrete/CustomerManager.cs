using DataAccess.Abstract;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using System.Linq.Expressions;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Entities.DTOs;
using Business.Constants;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return new SuccessDataResult<List<Customer>>( _customerDal.GetAll());
        }

        public IDataResult <Customer> BringById(int id)
        {
            return new SuccessDataResult<Customer>( _customerDal.Get(c=>c.Id==id));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }
        
        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }
    }
}
