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
    public class AdminTopicController : ControllerBase
    {
        private readonly ITopicAppService _TopicAppService;
        public AdminTopicController(ITopicAppService TopicAppService)
        {
            _TopicAppService = TopicAppService;
        }
        [HttpGet]
        [Route("AdminGetAllTopic")]
        public IActionResult AdminGetAllTopic(int page = 1, int pageSize = 10)
        {
            var model = _TopicAppService.AdminGetAllTopic(page, pageSize);
            return Ok(model);
        }
        [HttpGet]
        [Route("AdminGetDetailTopic")]
        public IActionResult AdminGetDetailTopic(int id)
        {
            var model = _TopicAppService.GetDetailsTopic(id);
            return Ok(model);
        }
        [HttpPost]
        [Route("CreateTopic")]
        public IActionResult CreateTopic([FromBody]Post post)
        {
            if (ModelState.IsValid)
            {
                var model = _TopicAppService.CreateTopic(post);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPut]
        [Route("UpdateTopic")]
        public IActionResult Update([FromBody]Post post)
        {
            if (ModelState.IsValid)
            {
                var model = _TopicAppService.UpdateTopic(post);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("DeleteTopic")]
        public IActionResult DeleteTopic(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _TopicAppService.DeleteTopic(id);
                return Ok(model);
            }
            return NotFound();
        }
    }
}