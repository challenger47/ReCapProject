using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.RentDate).NotEmpty().LessThan(DateTime.Now);//.WithMessage("") ile mesajda eklenebilir..Boş veya geçmiş tarihli olamaz
            RuleFor(p=>p.VehicleId).NotEmpty();
            RuleFor(p => p.CustomerId).NotEmpty();
           


        }

    }
}
