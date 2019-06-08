using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service.Manufacturer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerAppService _manufacturerAppService;
        public ManufacturerController(IManufacturerAppService manufacturerAppService)
        {
            _manufacturerAppService = manufacturerAppService;
        }
        [HttpGet]
        public IActionResult GetManufacturerInHome()
        {
            var model = _manufacturerAppService.GetManufacturerInHome();
            return Ok(model);
        }
    }
}