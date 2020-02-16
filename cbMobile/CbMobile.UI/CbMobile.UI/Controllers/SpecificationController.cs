using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationController : ControllerBase
    {
        private readonly ISpecificationAppService _specificationAppService;
        public SpecificationController(ISpecificationAppService specificationAppService)
        {
            _specificationAppService = specificationAppService;
        }
        [HttpGet]
        [Route("GetUISpecificationById")]
        public IActionResult GetUISpecificationById(int id)
        {
            return Ok(_specificationAppService.GetUISpecificationById(id));
        }
    }
}