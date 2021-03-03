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
           // fakat bu hatayı işlk defa veriyor bilginiz olsun evet biliyorum diğer hata çözüldü zatteen  NASIL ÇÖZÜLDÜ ? BEN GÖRMEDİM :D //bunun olmaması gerekiyor çünkü dosya gönderdiğinde imagepath boş geliyor
            RuleFor(v => v.VehicleId).NotEmpty();
        }
    }
}
