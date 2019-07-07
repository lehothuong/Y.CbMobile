using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobileApplication.Service;
using CbMobileApplication.Service.CategoryPost;
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
        public IActionResult GetCategoryNewMenu()
        {
            var model = _categoryPostAppService.GetCategoryNewMenu();
            return Ok(model);
        }
    }
}