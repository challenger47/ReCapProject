using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ImageValidator:AbstractValidator<Image>
    {
       public ImageValidator()
        {
            RuleFor(v => v.ImagePath).NotEmpty();
            RuleFor(v => v.VehicleId).NotEmpty();
        }
    }
}
