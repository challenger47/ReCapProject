using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.DTOs;
using System.Text;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<List<Image>> GetAll(Expression<Func<Image, bool>> filter = null);
        IResult Add(IFormFile file, Image image);
        IResult Update(IFormFile file, Image image);
        IResult Delete(Image image);
        IDataResult<Image> Get(int id);

        IDataResult<List<Image>> GetByVehicleId(int id);
    }
}
