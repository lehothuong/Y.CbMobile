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
    public class AdminLocationController : ControllerBase
    {
        private readonly ILocationAppService _locationAppService;
        public AdminLocationController(ILocationAppService locationAppService)
        {
            _locationAppService = locationAppService;
        }
        [HttpGet]
        [Route("AdminGetAllLocation")]
        public IActionResult AdminGetAllLocation(int page = 1, int pageSize = 10)
        {
            var model = _locationAppService.AdminGetAllLocation(page, pageSize);
            return Ok(model);
        }
        [HttpGet]
        [Route("AdminGetDetailLocation")]
        public IActionResult AdminGetDetailLocation(int id)
        {
            var model = _locationAppService.GetDetailsLocation(id);
            return Ok(model);
        }
        [HttpPost]
        [Route("CreateLocation")]
        public IActionResult CreateTopic([FromBody]Location location)
        {
            if (ModelState.IsValid)
            {
                var model = _locationAppService.CreateLocation(location);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateLocation")]
        public IActionResult Update([FromBody]Location location)
        {
            if (ModelState.IsValid)
            {
                var model = _locationAppService.UpdateLocation(location);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("DeleteLocation")]
        public IActionResult DeleteLocationc(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _locationAppService.DeleteLocation(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}