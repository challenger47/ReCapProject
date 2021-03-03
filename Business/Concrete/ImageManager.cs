using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;

        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }

        [ValidationAspect(typeof(ImageValidator))]
        public IResult Add(IFormFile file, Image image)
        {
            var result = BusinessRules.Run(CheckIfImageLimit(image.VehicleId));

            if (result != null)
            {
                return result;
            }

            image.ImagePath = FileHelper.AddAsync(file);
            image.Date = DateTime.Now;
            _imageDal.Add(image);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(ImageValidator))]
        public IResult Delete(Image image)
        {
            IResult result = BusinessRules.Run(ImageDelete(image));

            if (result != null)
            {
                return result;
            }

            _imageDal.Delete(image);

            return new SuccessResult();
        }

        public IDataResult<Image> Get(int id)
        {
            return new SuccessDataResult<Image>(_imageDal.Get(p => p.Id == id));
        }





        [ValidationAspect(typeof(ImageValidator))]
        public IResult Update(IFormFile file, Image image)
        {
            image.ImagePath = FileHelper.UpdateAsync(_imageDal.Get(p => p.Id == image.Id).ImagePath, file);
            image.Date = DateTime.Now;

            _imageDal.Update(image);

            return new SuccessResult();
        }



        public IDataResult<List<Image>> GetAll(Expression<Func<Image, bool>> filter = null)
        {
            return new SuccessDataResult<List<Image>>(_imageDal.GetAll());
        }

        public IDataResult<List<Image>> GetByVehicleId(int id)
        {
            return new SuccessDataResult<List<Image>>(CheckIfCarImageIsEmpty(id));
        }



        private List<Image> CheckIfCarImageIsEmpty(int id)
        {
            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images\default.jpg");
            var result = _imageDal.GetAll(c => c.VehicleId == id).Any();

            if (!result)
            {
                return new List<Image> { new Image { VehicleId = id, ImagePath = path, Date = DateTime.Now } };
            }

            return _imageDal.GetAll(p => p.VehicleId == id);

        }

        private IResult ImageDelete(Image image)
        {
            try
            {
                File.Delete(image.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }

        private IResult CheckIfImageLimit(int vehicleId)
        {
            var carImagecount = _imageDal.GetAll(p => p.VehicleId == vehicleId).Count;

            if (carImagecount == 5)
            {
                return new ErrorResult(Messages.ImageLimit);
            }

            return new SuccessResult();
        }

    }
}
