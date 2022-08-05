using Business.Abstarct;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _ıCarService;
        public CarsController(ICarService ıCarService)
        {
            _ıCarService = ıCarService;
        }
        
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _ıCarService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _ıCarService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _ıCarService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]

        public IActionResult Update(Car car)
        {
            var result = _ıCarService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbycolorıd")]
        public IActionResult GetByColorId(int id)
        {
            var result = _ıCarService.GetByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandıd")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _ıCarService.GetByBrandId(id);
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    return Ok(result.Data);
                }
            }
            return BadRequest(result);
        }

        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail()
        {
            var result = _ıCarService.GetCarDetail();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    return Ok(result);
                }
            }
            return BadRequest(result);
        }
        [HttpGet("getbyıd")]
        public IActionResult GetById(int id)
        {
            var result = _ıCarService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
