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
    public class BannerController : ControllerBase
    {
        private readonly IBannerAppService _bannerAppService;
        public BannerController(IBannerAppService bannerAppService)
        {
            _bannerAppService = bannerAppService;
        }
        [HttpGet]
        [Route("GetBannerHome")]
        public ActionResult GetBannerHome()
        {
            return Ok(_bannerAppService.GetBannerHome());
        }
    }
}