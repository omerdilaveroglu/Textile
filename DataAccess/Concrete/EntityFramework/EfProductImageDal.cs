using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramawork;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductImageDal : EfEntityRepositoryBase<ProductImage, TextileContext>, IProductImageDal
    {
    }
}
