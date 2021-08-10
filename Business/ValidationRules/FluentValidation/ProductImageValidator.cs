using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductImageValidator :AbstractValidator<ProductImage>
    {
        public ProductImageValidator()
        {
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("Ürün id'si boş olamaz.");
            RuleFor(p => p.DateTime).NotEmpty().WithMessage("Zaman boş olamaz.");
            RuleFor(p => p.ImagePath).NotEmpty().WithMessage("Resim boş olamaz.");
        }
    }
}
