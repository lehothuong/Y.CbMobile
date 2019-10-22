using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service;
using CbMobile.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPostController : ControllerBase
    {
        private readonly IPostAppService _postAppService;
        public AdminPostController(IPostAppService postAppService)
        {
            _postAppService = postAppService;
        }
        [HttpGet]
        [Route("AdminGetAllPost")]
        public IActionResult AdminGetAllPost(int page = 1, int pageSize = 10)
        {
            return Ok(_postAppService.GetAllPost(page, pageSize));
        }
        [HttpGet]
        [Route("AdminGetDetailPost")]
        public IActionResult AdminGetDetailBanner(int id)
        {
            return Ok(_postAppService.GetDetailsPost(id));
        }
        [HttpPost]
        [Route("CreatePost")]
        public IActionResult CreatePost([FromBody]Post post)
        {
            if (ModelState.IsValid)
            {
                var model = _postAppService.CreatePost(post);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdatePost")]
        public IActionResult UpdateBanner([FromBody]Post post)
        {
            if (ModelState.IsValid)
            {
                var model = _postAppService.UpdatePost(post);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("DeletePost")]
        public IActionResult DeletePost(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _postAppService.DeletePost(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}