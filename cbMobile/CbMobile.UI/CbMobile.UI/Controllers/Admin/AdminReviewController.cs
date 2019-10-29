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
    public class AdminReviewController : ControllerBase
    {
        private readonly IReviewAppService _reviewAppService;
        public AdminReviewController(IReviewAppService reviewAppService)
        {
            _reviewAppService = reviewAppService;
        }
        [HttpGet]
        [Route("AdminGetAllReview")]
        public IActionResult AdminGetAllTopic(int page = 1, int pageSize = 10)
        {
            var model = _reviewAppService.AdminGetAllReview(page, pageSize);
            return Ok(model);
        }
        [HttpDelete]
        [Route("DeleteReview")]
        public IActionResult DeleteTopic(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _reviewAppService.DeleteReview(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}