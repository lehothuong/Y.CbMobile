using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobileApplication.Service.Product;
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
    }
}