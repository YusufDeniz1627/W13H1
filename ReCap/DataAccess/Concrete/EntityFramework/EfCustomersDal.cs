using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomersDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomersDal
    {
        public List<CustomerDetailDto> GetCustomerDetail()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.Id equals u.Id
                             select new CustomerDetailDto 
                             {
                                 UserId=c.UserId,
                                 FirstName=u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName=c.CompanyName,
                                 Email=u.Email,
                                 Password=u.Passwords
                             };
                return result.ToList();
            }
        }
    }
}
