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
    public class AdminCategoryPost : ControllerBase
    {
        private readonly ICategoryPostAppService _categoryPostAppService;
        public AdminCategoryPost(ICategoryPostAppService categoryPostAppService)
        {
            _categoryPostAppService = categoryPostAppService;
        }
        [HttpGet]
        [Route("AdminGetAllCategoryPost")]
        public IActionResult AdminGetAllCategoryPost(int page = 1, int pageSize = 10)
        {
            var model = _categoryPostAppService.GetAllCategoryPost(page, pageSize);
            return Ok(model);
        }
        [HttpGet]
        [Route("GetListDropdownCategoryPost")]
        public IActionResult GetListDropdownCategoryPost()
        {
            return Ok(_categoryPostAppService.GetListDropdownCategoryPost());
        }
        [HttpGet]
        [Route("AdminGetDetailCategoryPost")]
        public IActionResult AdminGetDetailCategoryPost(int id)
        {
            var model = _categoryPostAppService.GetDetailsCategoryPost(id);
            return Ok(model);
        }
        [HttpPost]
        [Route("CreateCategoryPost")]
        public IActionResult CreateCategoryPost([FromBody]Categories category)
        {
            if (ModelState.IsValid)
            {
                var model = _categoryPostAppService.CreateCategoryPost(category);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateCategoryPost")]
        public IActionResult UpdateCategory([FromBody]Categories category)
        {
            if (ModelState.IsValid)
            {
                var model = _categoryPostAppService.UpdateCategoryPost(category);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("DeleteCategoryPost")]
        public IActionResult DeleteCategoryPost(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _categoryPostAppService.DeleteCategoryPost(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}