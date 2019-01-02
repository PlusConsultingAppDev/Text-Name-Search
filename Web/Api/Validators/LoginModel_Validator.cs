﻿using FluentValidation;
using App.Membership.Models;

namespace App.Api.Validators
{
    public class LoginModel_Validator : AbstractValidator<LoginModel>
    {
        public LoginModel_Validator()
        {
            this.RuleFor(x => x.Username).NotEmpty().WithMessage("UserName is required");
            this.RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
