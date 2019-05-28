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

        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return 0;
        //}
    }
}