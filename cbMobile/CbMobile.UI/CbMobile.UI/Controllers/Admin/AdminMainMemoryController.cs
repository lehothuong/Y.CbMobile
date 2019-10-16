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
    public class AdminMainMemoryController : ControllerBase
    {
        private readonly IMainMemoryAppService _mainMemoryAppService;
        public AdminMainMemoryController(IMainMemoryAppService mainMemoryAppService)
        {
            _mainMemoryAppService = mainMemoryAppService;
        }
        [HttpGet]
        [Route("AdminGetAllMainMemory")]
        public IActionResult AdminGetAllMainMemory(int page = 1, int pageSize = 10)
        {
            var model = _mainMemoryAppService.GetAllMainMemory(page, pageSize);
            return Ok(model);
        }
        [HttpGet]
        [Route("AdminGetListDropdownMainMemory")]
        public IActionResult AdminGetListDropdownMainMemory()
        {
            return Ok(_mainMemoryAppService.GetListMainMemory());
        }
        [HttpGet]
        [Route("AdminGetDetailMainMemory")]
        public IActionResult AdminGetDetailMainMemory(int id)
        {
            var model = _mainMemoryAppService.GetDetailMainMemory(id);
            return Ok(model);
        }
        [HttpPost]
        [Route("CreateMainMemory")]
        public IActionResult CreateMainMemory([FromBody]MainMemory mainMemory)
        {
            if (ModelState.IsValid)
            {
                var model = _mainMemoryAppService.CreateMainMemory(mainMemory);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateMainMemory")]
        public IActionResult UpdateMainMemory([FromBody]MainMemory mainMemory)
        {
            if(ModelState.IsValid)
            {
                var model = _mainMemoryAppService.UpdateMainMemory(mainMemory);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("DeleteMainMemory")]
        public IActionResult DeleteMainMemory(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _mainMemoryAppService.DeleteMainMemory(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}