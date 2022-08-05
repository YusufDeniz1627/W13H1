using Business.Abstarct;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UsersManager : IUsersService
    {
        IUsersDal _ıUsersDal;

        public UsersManager(IUsersDal ıUsersDal)
        {
            _ıUsersDal = ıUsersDal;
        }

        [ValidationAspect(typeof(UsersValidator))]
        public IResult Add(User user)
        {
                _ıUsersDal.Add(user);
                return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _ıUsersDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_ıUsersDal.GetAll(),Messages.UsersListed);
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_ıUsersDal.Get(s => s.Id == Id));
        }

        public IResult Update(User user)
        {
            _ıUsersDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
