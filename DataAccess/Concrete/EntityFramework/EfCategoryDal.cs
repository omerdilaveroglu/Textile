using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramawork;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal :EfEntityRepositoryBase<Category,TextileContext>,ICategoryDal
    {
    }
}
