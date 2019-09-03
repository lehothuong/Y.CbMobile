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
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeAppService _subscribeAppService;
        public SubscribeController(ISubscribeAppService subscribeAppService)
        {
            _subscribeAppService = subscribeAppService;
        }
        [HttpPost]
        [Route("PostSubscribe")]
        public ActionResult PostContact([FromBody]Subscribe subscribe)
        {
            if (ModelState.IsValid)
            {
                var model = _subscribeAppService.PostSubscribe(subscribe);
                return Ok(model);
            }
            return NotFound();
        }
    }
}