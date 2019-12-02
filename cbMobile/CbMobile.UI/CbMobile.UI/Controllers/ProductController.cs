using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        [HttpGet]
        [Route("GetProductHotInHome")]
        public IActionResult GetProductHotInHome()
        {
            var model = _productAppService.GetProduct();
            return Ok(model);
        }
        [HttpGet]
        [Route("GetPhoneProductInHome")]
        public IActionResult GetPhoneProductInHome()
        {
            var model = _productAppService.GetPhoneProductInHome();
            return Ok(model);
        }
        [HttpGet("GetDetails")]
        public ActionResult GetDetails(int id)
        {
            var model = _productAppService.GetDetails(id);
            return Ok(model);
        }
        [HttpGet("GetDetailAccessoriesById")]
        public ActionResult GetDetailAccessoriesById(int mainMemoryId, int mainColorId)
        {
            var model = _productAppService.GetDetailAccessoriesById(mainMemoryId, mainColorId);
            return Ok(model);
        }
        //[HttpGet("GetDetailMainMemory")]
        //public ActionResult GetDetailMainMemory(int id)
        //{
        //    var model = _productAppService.GetMainMemory(id);
        //    return Ok(model);
        //}
        [HttpGet("GetGenericProduct")]
        public ActionResult GetGenericProduct(int id)
        {
            var model = _productAppService.GetGenericProduct(id);
            return Ok(model);
        }
        [HttpGet("GetIndexProductById")]
        public ActionResult GetIndexProductById(int id)
        {
            var model = _productAppService.GetIndexProductById(id);
            return Ok(model);
        }
        [HttpGet("GetIndexManufactureById")]
        public ActionResult GetIndexManufactureById(int id,int idCategory)
        {
            var model = _productAppService.GetIndexManufactureById(id, idCategory);
            return Ok(model);
        }
    }
}