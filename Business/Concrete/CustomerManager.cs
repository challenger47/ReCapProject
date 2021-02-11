using DataAccess.Abstract;
using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void Add(Customer vehicle)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customerDal.Get(c=>c.Id==id);
        }

        public void Update(Customer vehicle)
        {
            throw new NotImplementedException();
        }
    }
}
