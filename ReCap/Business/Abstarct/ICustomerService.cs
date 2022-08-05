using Core.Utilities.Results;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstarct
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int Id);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetail();

        IResult Add(Customer customer);
        IResult Deleted(Customer customer);
        IResult Updated(Customer customer);
    }
}
