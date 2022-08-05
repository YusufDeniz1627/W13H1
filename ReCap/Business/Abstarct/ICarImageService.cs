using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstarct
{
    public interface ICarImageService
    {
        IResult Add(IFormFile formFile, CarImages carImage);
        IResult Update(IFormFile formFile,CarImages carImage);
        IResult Delete(CarImages carImage);

        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetById(int id);
        IDataResult<List<CarImages>> GetByCarId(int id);
    }
}
