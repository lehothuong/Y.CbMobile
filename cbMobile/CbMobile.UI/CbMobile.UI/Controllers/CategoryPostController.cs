using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service;
using CbMobile.Application.Service.CategoryPost;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers.CategoryPost
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryPostController : ControllerBase
    {
        private readonly ICategoryPostAppService _categoryPostAppService;
        public CategoryPostController(ICategoryPostAppService categoryPostAppService)
        {
            _categoryPostAppService = categoryPostAppService;
        }
        [HttpGet]
        [Route("GetCategoryNewMenu")]
        public ActionResult GetCategoryNewMenu()
        {
            var model = _categoryPostAppService.GetCategoryNewMenu();
            return Ok(model);
        }
        [HttpGet]
        [Route("GetListById")]
        public ActionResult GetListById(int id)
        {
            var model = _categoryPostAppService.GetListById(id);
            return Ok(model);
        }
    }
}