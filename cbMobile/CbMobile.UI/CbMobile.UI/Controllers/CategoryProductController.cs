using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryProductController : ControllerBase
    {
        private readonly ICategoryProductAppService _categoryProductAppService;
        private readonly IManufacturerAppService _manufacturerAppService;
        public CategoryProductController(
            ICategoryProductAppService categoryProductAppService,
            IManufacturerAppService manufacturerAppService)
        {
            _categoryProductAppService = categoryProductAppService;
            _manufacturerAppService = manufacturerAppService;
        }
        [HttpGet]
        [Route("GetMenuCategoryProduct")]
        public IActionResult GetMenuCategoryProduct()
        {
            var model = _categoryProductAppService.GetMenuCategory();
            return Ok(model);
        }
        [HttpGet]
        [Route("GetCategoryProductById")]
        public IActionResult GetCategoryProductById(int id)
        {
            var model = _categoryProductAppService.GetCategoryProductById(id);
            return Ok(model);
        }
        [HttpGet]
        [Route("GetManuFacturerById")]
        public IActionResult GetManufacturerById(int id)
        {
            var model = _manufacturerAppService.GetManuFacturerById(id);
            return Ok(model);
        }
    }
}