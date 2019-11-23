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
    public class AdminMainColorController : ControllerBase
    {
        private readonly IMainColorAppService _mainColorAppService;
        public AdminMainColorController(IMainColorAppService mainColorAppService)
        {
            _mainColorAppService = mainColorAppService;
        }
        [HttpGet]
        [Route("AdminGetAllMainColor")]
        public IActionResult AdminGetAllMainColor(int page = 1, int pageSize = 10)
        {
            var model = _mainColorAppService.GetAllMainColor(page, pageSize);
            return Ok(model);
        }
        [HttpGet]
        [Route("AdminGetListDropdownMainColor")]
        public IActionResult AdminGetListDropdownMainColor()
        {
            return Ok(_mainColorAppService.GetListMainColor());
        }
        [HttpGet]
        [Route("AdminGetDetailMainColor")]
        public IActionResult AdminGetDetailMainColor(int id)
        {
            var model = _mainColorAppService.GetDetailMainColor(id);
            return Ok(model);
        }
        [HttpPost]
        [Route("CreateMainColor")]
        public IActionResult CreateMainColor([FromBody]MainColor mainColor)
        {
            if (ModelState.IsValid)
            {
                var model = _mainColorAppService.CreateMainColor(mainColor);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateMainColor")]
        public IActionResult UpdateMainColor([FromBody]MainColor mainColor)
        {
            if(ModelState.IsValid)
            {
                var model = _mainColorAppService.UpdateMainColor(mainColor);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("DeleteMainColor")]
        public IActionResult DeleteMainMemory(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _mainColorAppService.DeleteMainColor(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}