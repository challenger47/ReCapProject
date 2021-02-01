using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;
        public InMemoryBrandDal()
        {
            _brands = new List<Brand> {
                new Brand {Id=1, BrandName = "Toyota"},
                new Brand {Id=2, BrandName = "Opel"},
                new Brand {Id=3, BrandName = "Hyundai"},
                new Brand {Id=4, BrandName = "Mercedes"},
                
            };
        }

        public void Add(Brand brand)
        {
            Console.WriteLine("Marka Eklendi");
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.Id == brand.Id);
            _brands.Remove(brandToDelete);
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public List<Brand> GetByBrand(int brandId)
        {
            return _brands.Where(b => b.Id == brandId).ToList();
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.Id == brand.Id);
            brandToUpdate.Id = brand.Id;
            brandToUpdate.BrandName = brand.BrandName;
        }
    }
}
