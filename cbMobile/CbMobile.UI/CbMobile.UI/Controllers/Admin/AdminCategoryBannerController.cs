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
    public class AdminCategoryBannerController : ControllerBase
    {
        private readonly ICategoryBannerAppService _categoryBannerAppService;
        public AdminCategoryBannerController(ICategoryBannerAppService categoryBannerAppService)
        {
            _categoryBannerAppService = categoryBannerAppService;
        }
        [HttpGet]
        [Route("AdminGetAllCategoryBanner")]
        public IActionResult AdminGetAllCategoryBanner(int page = 1, int pageSize = 10)
        {
            var model = _categoryBannerAppService.GetAllCategoryBanner(page, pageSize);
            return Ok(model);
        }
        [HttpGet]
        [Route("GetListDropdownCategoryBanner")]
        public IActionResult GetListDropdownCategoryBanner()
        {
            return Ok(_categoryBannerAppService.GetListDropdownCategoryBanner());
        }
        [HttpGet]
        [Route("AdminGetDetailCategoryBanner")]
        public IActionResult AdminGetDetailCategoryBanner(int id)
        {
            var model = _categoryBannerAppService.GetDetailsCategoryBanner(id);
            return Ok(model);
        }
        [HttpPost]
        [Route("CreateCategoryBanner")]
        public IActionResult CreateCategoryBanner([FromBody]Categories category)
        {
            if (ModelState.IsValid)
            {
                var model = _categoryBannerAppService.CreateCategoryBanner(category);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateCategoryBanner")]
        public IActionResult UpdateCategory([FromBody]Categories category)
        {
            if (ModelState.IsValid)
            {
                var model = _categoryBannerAppService.UpdateCategoryBanner(category);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("DeleteCategoryBanner")]
        public IActionResult DeleteCategoryBanner(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _categoryBannerAppService.DeleteCategoryBanner(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}