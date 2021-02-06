using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            if (color.Name.Length < 2)
            {
                Console.WriteLine("marka ismi en az 3 karakter olmalıdır Girdiğiniz değer: " + color.Name);
            }
            else
            {
                _colorDal.Add(color);
                Console.WriteLine("Renk başarıyla eklendi.");

            }
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Color başarıyla silindi.");

        }

       

        public Color BringById(int id)
        {
            return _colorDal.Get(c => c.Id == id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine(color.Id + " Id li color Bilgileri Güncellendi");

        }

       
    }
}
