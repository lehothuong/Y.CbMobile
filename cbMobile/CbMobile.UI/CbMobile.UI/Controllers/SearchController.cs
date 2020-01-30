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
    public class SearchController : ControllerBase
    {
        private readonly ISearchAppService _searchAppService;
        public SearchController(ISearchAppService searchAppService)
        {
            _searchAppService = searchAppService;
        }
        [HttpGet]
        [Route("Filter")]
        public ActionResult Filter(string keyword)
        {
             return Ok(_searchAppService.Filter(keyword));
        }
    }
}