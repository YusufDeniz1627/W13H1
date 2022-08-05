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
    public class ColorManager : IColorService
    {
        IColorDal _ıColorDal;

        public ColorManager(IColorDal ıColorDal)
        {
            _ıColorDal = ıColorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
                _ıColorDal.Add(color);
                return new SuccessResult();
            
        }

        public IResult Delete(Color color)
        {
            _ıColorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_ıColorDal.GetAll(),Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_ıColorDal.Get(c=>c.Id == id),Messages.ColorListed);
        }

        public IResult Update(Color color)
        {
            _ıColorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
