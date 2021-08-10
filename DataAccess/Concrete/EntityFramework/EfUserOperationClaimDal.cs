using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramawork;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal:EfEntityRepositoryBase<UserOperationClaim,TextileContext>,IUserOperationClaimDal
    {
    }
}
