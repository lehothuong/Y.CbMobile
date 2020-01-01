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
    public class AdminContactController : ControllerBase
    {
        private readonly IContactAppService _contactAppService;
        public AdminContactController(IContactAppService contactAppService)
        {
            _contactAppService = contactAppService;
        }
        [HttpGet]
        [Route("AdminGetAllContact")]
        public IActionResult AdminGetAllContact(int page = 1, int pageSize = 10)
        {
            var model = _contactAppService.AdminGetAllContact(page, pageSize);
            return Ok(model);
        }
        [HttpDelete]
        [Route("DeleteContact")]
        public IActionResult DeleteContact(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _contactAppService.DeleteContact(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}