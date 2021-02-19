﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            if (color.Name.Length < 2)
            {
                return new ErrorResult();
            }
            else
            {
                _colorDal.Add(color);
                return new SuccessResult();

            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult< List < Color >>( _colorDal.GetAll());
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();

        }

       

        public IDataResult<Color> BringById(int id)
        {
            return new SuccessDataResult<Color>( _colorDal.Get(c => c.Id == id));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();

        }

       
    }
}
