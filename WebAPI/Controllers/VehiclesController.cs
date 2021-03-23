using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            Thread.Sleep(3000);
            var result = _vehicleService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Vehicle vehicle)
        {
            var result = _vehicleService.Add(vehicle);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Vehicle vehicle)
        {
            var result = _vehicleService.Update(vehicle);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("bringbyid")]
        public  IActionResult BringById(int id)
        {
            var result = _vehicleService.BringById(id);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Vehicle vehicle)
        {
            var result = _vehicleService.Delete(vehicle);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbybrand")]
        public IActionResult GetByBrand(int brandId)
        {
            var result = _vehicleService.GetVehiclesByBrandId(brandId);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycolor")]
        public IActionResult GetByColor(int id)
        {
            var result = _vehicleService.GetVehiclesByColorId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getdetails")]
        public IActionResult GetVehicleDetails()
        {
            var result = _vehicleService.GetVehicleDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getvehicledetailsbyvehicleid")]
        public IActionResult GetVehicleDetailsByVehicleId(int id)
        {
            var result = _vehicleService.GetVehicleDetailsByVehicleId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getvehicledetailsbybrandid")]
        public IActionResult GetVehicleDetailsByBrandId(int brandId)
        {

            var result = _vehicleService.GetVehicleDetailsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getvehicledetailsbycolorid")]
        public IActionResult GetVehiclesByColorId(int colorId)
        {

            var result = _vehicleService.GetVehicleDetailsByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
