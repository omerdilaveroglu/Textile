using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IDataResult<ProductImage> Get(int id);
        IDataResult<List<ProductImage>> GetAll();

        IResult Add(IFormFile file, ProductImage productImage);
        IResult Update(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
    }
}
