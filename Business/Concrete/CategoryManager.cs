using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [PerformanceAspect(45)]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),Messages.CategoryListed);
        }
        [PerformanceAspect(45)]
        public IDataResult<List<Category>> GetById(int id)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c => c.CategoryId == id));
        }
    }
}
