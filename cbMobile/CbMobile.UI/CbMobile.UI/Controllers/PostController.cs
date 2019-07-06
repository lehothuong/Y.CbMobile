using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobileApplication.Service.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostAppService _postAppService;
        public PostController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }

        [HttpGet]
        [Route("GetAboutUs")]
        public IActionResult GetAboutUs()
        {
            var model = _postAppService.GetAboutUs();
            return Ok(model);
        }
    }
}