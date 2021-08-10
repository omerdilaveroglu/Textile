using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Aspects.Autofac.Performance;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [PerformanceAspect(45)]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        [PerformanceAspect(45)]
        public void Add(User user)
        {
            _userDal.Add(user);
        }
        [PerformanceAspect(45)]
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
