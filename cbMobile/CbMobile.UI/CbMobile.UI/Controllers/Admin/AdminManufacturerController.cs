using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service;
using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminManufacturerController : ControllerBase
    {
        private readonly IManufacturerAppService _manufacturerAppService;
        public AdminManufacturerController(IManufacturerAppService manufacturerAppService)
        {
            _manufacturerAppService = manufacturerAppService;
        }
        [HttpGet]
        [Route("AdminGetAllManufacturer")]
        public IActionResult AdminGetAllManufacturer(int page = 1, int pageSize = 10)
        {
            var model = _manufacturerAppService.GetAllManufacturer(page, pageSize);
            return Ok(model);
        }
        [HttpGet]
        [Route("AdminGetListDropdownManufacturer")]
        public IActionResult AdminGetListDropdownManufacturer()
        {
            return Ok(_manufacturerAppService.GetListDropdownManufacturer());
        }
        [HttpGet]
        [Route("AdminGetDetailManufacturer")]
        public IActionResult AdminGetDetailCategoryProduct(int id)
        {
            var model = _manufacturerAppService.GetDetailsManufacturer(id);
            return Ok(model);
        }
        [HttpPost]
        [Route("CreateManufacturer")]
        public IActionResult CreateCategoryProduct([FromBody]Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                var model = _manufacturerAppService.CreateManufacturer(manufacturer);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateManufacturer")]
        public IActionResult UpdateCategoryProduct([FromBody]Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                var model = _manufacturerAppService.UpdateManufacturer(manufacturer);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("DeleteManufacturer")]
        public IActionResult DeleteManufacturer(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _manufacturerAppService.DeleteCategoryProduct(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}