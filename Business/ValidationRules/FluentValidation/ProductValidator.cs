﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {  //validator kuralları bunun ıcıne yazıyoruz.
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            //aşagıdakı kural categoryıd=1 olan fyat 10 dan buyuk olmalı.
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(startWithA).WithMessage("Ürünler A harfi ile başlamalı");
        }

        private bool startWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}