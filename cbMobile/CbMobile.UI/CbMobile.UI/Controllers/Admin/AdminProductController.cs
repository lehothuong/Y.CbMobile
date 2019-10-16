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
    public class AdminProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public AdminProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        [HttpGet]
        [Route("AdminGetAllProduct")]
        public IActionResult AdminGetAllCategoryProduct(int page = 1, int pageSize = 10)
        {
            var model = _productAppService.GetAllProduct(page, pageSize);
            return Ok(model);
        }
        [HttpGet]
        [Route("AdminGetDetailProduct")]
        public IActionResult AdminGetDetailCategoryProduct(int id)
        {
            var model = _productAppService.GetDetailsProduct(id);
            return Ok(model);
        }
        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult CreateCategoryProduct([FromBody]Product product)
        {
            if (ModelState.IsValid)
            {
                var model = _productAppService.CreateProduct(product);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public IActionResult UpdateCategoryProduct([FromBody]Product product)
        {
            if(ModelState.IsValid)
            {
                var model = _productAppService.UpdateProduct(product);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("DeleteProduct")]
        public IActionResult DeleteCategoryProduct(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _productAppService.DeleteProduct(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}