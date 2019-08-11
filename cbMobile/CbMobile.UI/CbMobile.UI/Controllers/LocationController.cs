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
    public class LocationController : ControllerBase
    {
        private readonly ILocationAppService _locationAppService;
        public LocationController(ILocationAppService locationAppService)
        {
            _locationAppService = locationAppService;
        }
        [HttpGet]
        [Route("GetAllLocation")]
        public ActionResult GetAllLocation()
        {
            return Ok( _locationAppService.GetAllLocation() );
        }
    }
}