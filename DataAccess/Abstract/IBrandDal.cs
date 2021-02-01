using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal
    {
        List<Brand> GetAll();
        void Add(Brand model);
        void Delete(Brand model);
        void Update(Brand model);
        
    }
}
