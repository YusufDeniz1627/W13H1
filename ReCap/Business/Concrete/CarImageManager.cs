using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(IFileHelper fileHelper, ICarImageDal carImageDal)
        {
            _fileHelper = fileHelper;
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile formFile, CarImages carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(formFile, PathConstanst.ImagesPath);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.UploadImage);
        }

        public IResult Delete(CarImages carImage)
        {
            _fileHelper.Delete(PathConstanst.ImagesPath+carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll());   
        }

        public IDataResult<List<CarImages>> GetByCarId(int id)
        {
            var result = BusinessRules.Run(CheckIfCarImageExist(id));
            if (result!=null)
            {
                return new ErrorDataResult<List<CarImages>>(GetDefaultImage(id).Data);
            }

            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(c=>c.Id==id)) ;
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(c=>c.Id==id));
        }

        public IResult Update(IFormFile formFile, CarImages carImage)
        {
            carImage.ImagePath = _fileHelper.Update(formFile,PathConstanst.ImagesPath+carImage.ImagePath,PathConstanst.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ImageUpdated);
        }

        private IDataResult<List<CarImages>> GetDefaultImage(int carId)
        {
            List<CarImages> carImages = new List<CarImages>();

            carImages.Add(new CarImages { CarId = carId, ImageDate = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<CarImages>>(carImages);
        }

        private IResult CheckIfCarImageExist(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if (result>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId==carId);
            if (result.Count() >= 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            return new SuccessResult();
        }
    }
}
