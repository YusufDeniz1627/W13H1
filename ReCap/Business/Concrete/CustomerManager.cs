using Business.Abstarct;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomersDal _ıCustomerDal;

        public CustomerManager(ICustomersDal ıCustomerDal)
        {
            _ıCustomerDal = ıCustomerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
                _ıCustomerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Deleted(Customer customer)
        {
            _ıCustomerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_ıCustomerDal.GetAll(),Messages.CustomerListed);
        }

        public IDataResult<Customer> GetById(int Id)
        {
            return new SuccessDataResult<Customer>(_ıCustomerDal.Get(c=>c.UserId==Id),Messages.CustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_ıCustomerDal.GetCustomerDetail(),Messages.CustomerDetailListed);
        }

        public IResult Updated(Customer customer)
        {
            _ıCustomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
