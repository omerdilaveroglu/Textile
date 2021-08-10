using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().MinimumLength(2).WithMessage("Ürün ismi ne az iki karakter olmalıdır.");
            RuleFor(p => p.BodySize).NotEmpty().WithMessage("Lütfen bir beden giriniz.");
            RuleFor(p => p.UnitsInStock).NotEmpty().WithMessage("Stok adedi boş olamaz.");
            RuleFor(p=>p.Color).NotEmpty().MinimumLength(3).WithMessage("Ürün rengi ne az iki karakter olmalıdır.");
            RuleFor(p => p.UnitPrice).NotEmpty().GreaterThan(0).WithMessage("Ürün fiyatı sıfırdan büyük olmalıdır.");
            
            
        }
    }
}
