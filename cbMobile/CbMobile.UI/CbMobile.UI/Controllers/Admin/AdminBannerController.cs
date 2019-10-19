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
    public class AdminBannerController : ControllerBase
    {
        private readonly IBannerAppService _bannerAppService;
        public AdminBannerController(IBannerAppService bannerAppService)
        {
            _bannerAppService = bannerAppService;
        }
        [HttpGet]
        [Route("AdminGetAllBanner")]
        public IActionResult AdminGetAllBanner(int page = 1, int pageSize = 10)
        {
            return Ok(_bannerAppService.GetAllBanner(page, pageSize));
        }
        [HttpGet]
        [Route("AdminGetDetailBanner")]
        public IActionResult AdminGetDetailBanner(int id)
        {
            return Ok(_bannerAppService.GetDetailsBanner(id));
        }
        [HttpPost]
        [Route("CreateBanner")]
        public IActionResult CreateBanner([FromBody]Banner banner)
        {
            if (ModelState.IsValid)
            {
                var model = _bannerAppService.CreateBanner(banner);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateBanner")]
        public IActionResult UpdateBanner([FromBody]Banner banner)
        {
            if (ModelState.IsValid)
            {
                var model = _bannerAppService.UpdateBanner(banner);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("DeleteBanner")]
        public IActionResult DeleteBanner(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _bannerAppService.DeleteBanner(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}