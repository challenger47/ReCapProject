using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class VehicleValidator:AbstractValidator<Vehicle>
    {
        public VehicleValidator()
        {
            RuleFor(p => p.VehicleName).NotEmpty();//.WithMessage("") ile mesajda eklenebilir
            RuleFor(p => p.VehicleName).MinimumLength(2);
            RuleFor(p => p.DailyPrice).GreaterThan(0); //.When(p=>p.CategoryId==1) bu projede bu kısım lazım değil

            //greaterthan var maximumlength var. when özelliği ile istediğin şarta özel validation kullanbilirsin
            //Must() ile parantez içine kendi şartını da yazabilrsin o şarta bi fonksiyon oluşturmalısın generate method ile.. 

        }
    }
}
