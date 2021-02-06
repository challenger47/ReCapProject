using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                Console.WriteLine("marka ismi en az 2 karakter olmalıdır Girdiğiniz değer: "+brand.BrandName);
            }
            else 
            {
                _brandDal.Add(brand);
                Console.WriteLine("Marka başarıyla eklendi.");
                
            }
        }

        

       
        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("Marka başarıyla silindi.");

        }

       

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

       
        public List<Brand> GetAllByColorId(int id)
        {
            throw new NotImplementedException();
        }

        public Brand BringById(int id)
        {
            return _brandDal.Get(c => c.Id == id);
        }

        public void Update(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Update(brand);
                Console.WriteLine("Marka başarıyla Güncellendi.");
            }
            else
            {
                Console.WriteLine($"Lütfen marka isminin uzunluğunu 1 karakterden fazla giriniz. Girdiğiniz marka ismi : {brand.BrandName}");
            }

        }

        
    }
}
