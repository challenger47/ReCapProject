using DataAccess.Abstract;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return new SuccessDataResult<List<Customer>>( _customerDal.GetAll());
        }

        public IDataResult <Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>( _customerDal.Get(c=>c.Id==id));
        }

        public IResult Update(Customer customer)
        {
            return new SuccessResult();
        }
    }
}
