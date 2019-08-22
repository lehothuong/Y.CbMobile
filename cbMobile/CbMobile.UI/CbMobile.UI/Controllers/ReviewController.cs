using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service;
using CbMobile.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewAppService _reviewAppService;
        public ReviewController(IReviewAppService reviewAppService)
        {
            _reviewAppService = reviewAppService;
        }
        [HttpPost]
        [Route("PostReview")]
        public ActionResult PostReview([FromBody]Review review)
        {
            if (ModelState.IsValid)
            {
                var model = _reviewAppService.PostReview(review);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("GetAllReviewByProductId")]
        public ActionResult GetAllReviewByProductId(int id)
        {
            var model = _reviewAppService.GetAllReviewByProductId(id);
            return Ok(model);
        }
    }
}