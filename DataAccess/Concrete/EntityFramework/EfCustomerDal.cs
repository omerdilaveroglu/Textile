﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramawork;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, TextileContext>, ICustomerDal
    {
    }
}
