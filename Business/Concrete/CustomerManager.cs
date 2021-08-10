using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrate;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Validators;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [PerformanceAspect(45)]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            IResult result = BusinessRules.Run(CustomerNameAlreadyExists(customer.CustomerName));
            if (result != null)
            {
                return new ErrorResult(Messages.CustomerNameAlreadyExists);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }
        [PerformanceAspect(45)]
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            IResult result = BusinessRules.Run(CustomerNameAlreadyExists(customer.CustomerName));
            if (result != null)
            {
                return new ErrorResult(Messages.CustomerNameAlreadyExists);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
        [PerformanceAspect(45)]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }
        [PerformanceAspect(45)]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }
        [PerformanceAspect(45)]
        public IDataResult<List<Customer>> GetById(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(p => p.CustomerId == id));
        }

        

        public IResult CustomerNameAlreadyExists(string customerName)
        {
            var result = _customerDal.GetAll(p => p.CustomerName == customerName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CustomerNameAlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
