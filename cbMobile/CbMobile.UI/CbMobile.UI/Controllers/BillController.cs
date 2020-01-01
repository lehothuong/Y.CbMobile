using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service;
using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillAppService _billAppService;
        public BillController(IBillAppService billAppService)
        {
            _billAppService = billAppService;
        }
        [HttpPost]
        [Route("PostPill")]
        public IActionResult PostOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var model = _billAppService.PostOrder(order);
                return Ok(model);
            }
            return NotFound();
        }
    }
}