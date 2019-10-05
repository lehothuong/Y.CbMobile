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
    public class AdminCategoryProductController : ControllerBase
    {
        private readonly ICategoryProductAppService _categoryProductAppService;
        public AdminCategoryProductController(ICategoryProductAppService categoryProductAppService)
        {
            _categoryProductAppService = categoryProductAppService;
        }
        [HttpGet]
        [Route("AdminGetAllCategoryProduct")]
        public IActionResult AdminGetAllCategoryProduct(int page = 1, int pageSize = 10)
        {
            var model = _categoryProductAppService.GetAllCategory(page, pageSize);
            return Ok(model);
        }
        [HttpGet]
        [Route("AdminGetDetailCategoryProduct")]
        public IActionResult AdminGetDetailCategoryProduct(int id)
        {
            var model = _categoryProductAppService.GetDetailsCategoryProduct(id);
            return Ok(model);
        }
        [HttpPost]
        [Route("CreateCategoryProduct")]
        public IActionResult CreateCategoryProduct([FromBody]CategoryProduct categoryProduct)
        {
            if (ModelState.IsValid)
            {
                var model = _categoryProductAppService.CreateCategoryProduct(categoryProduct);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateCategoryProduct")]
        public IActionResult UpdateCategoryProduct([FromBody]CategoryProduct categoryProduct)
        {
            if(ModelState.IsValid)
            {
                var model = _categoryProductAppService.UpdateCategoryProduct(categoryProduct);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("DeleteCategoryProduct")]
        public IActionResult DeleteCategoryProduct(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _categoryProductAppService.DeleteCategoryProduct(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}