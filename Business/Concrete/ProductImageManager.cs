using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        [PerformanceAspect(45)]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Add(IFormFile file, ProductImage productImage)
        {
            string ImagePath = FileHelper.Add(file);
            IResult result = BusinessRules.Run(CheckIfProductImagesCompleted(productImage.ProductId));
            if (result == null && ImagePath != null)
            {
                productImage.DateTime = DateTime.Now; //// Resmin eklendiği tarih sistem tarafından alınır.
                productImage.ImagePath = FileHelper.Add(file);
                _productImageDal.Add(productImage);

                return new SuccessResult(Messages.ProductImageAdded);
            }

            return new ErrorResult(Messages.ProductImageNotAdded);
        }
        [PerformanceAspect(45)]
        [SecuredOperation("product.add,admin")] 
        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Update(IFormFile file, ProductImage productImage)
        {
            productImage.ImagePath = FileHelper.Update(_productImageDal.Get(p => p.ProductImageId == productImage.ProductImageId).ImagePath, file);

            _productImageDal.Update(productImage);

            return new SuccessResult();
        }
        [PerformanceAspect(45)]
        [SecuredOperation("product.add,admin")]
        public IResult Delete(ProductImage productImage)
        {
            var result = this.Get(productImage.ProductImageId);
            var Deleted = FileHelper.Delete(result.Data.ImagePath);
            if (Deleted.Success)
            {
                _productImageDal.Delete(productImage);
                return new SuccessResult(Messages.ProductImageDeleted);
            }
            return new ErrorResult();
        }
        [PerformanceAspect(45)]
        public IDataResult<ProductImage> Get(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.ProductImageId == id));
        }
        [PerformanceAspect(45)]
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        // En fazla 5 tane resim olabilir. 
        private IResult CheckIfProductImagesCompleted(int productId) 
        {
            var result = _productImageDal.GetAll(p => p.ProductId == productId).Count;
            if (result > 10)
            {
                return new ErrorResult(Messages.CapacityFulled);
            }
            return new SuccessResult();
        }


    }
}
