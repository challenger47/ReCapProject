using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty();//.WithMessage("") ile mesajda eklenebilir
            RuleFor(p => p.LastName).NotEmpty();//.WithMessage("") ile mesajda eklenebilir
            RuleFor(p => p.EMail).NotEmpty();//.WithMessage("") ile mesajda eklenebilir
            RuleFor(p => p.Password).NotEmpty();//.WithMessage("") ile mesajda eklenebilir


        }

    }
}
