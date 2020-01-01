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
    public class AdminBillController : ControllerBase
    {
        private readonly IBillAppService _billAppService;
        public AdminBillController(IBillAppService billAppService)
        {
            _billAppService = billAppService;
        }
        [HttpGet]
        [Route("AdminGetAllBill")]
        public IActionResult AdminGetAllTopic(int page = 1, int pageSize = 10)
        {
            var model = _billAppService.AdminGetAllBill(page, pageSize);
            return Ok(model);
        }
        [HttpGet]
        [Route("AdminGetDetailBill")]
        public IActionResult AdminGetDetailBill(int id)
        {
            return Ok(_billAppService.GetDetailsBill(id));
        }
        [HttpGet]
        [Route("AdminGetDetailBillById")]
        public IActionResult AdminGetDetailBillById(int id)
        {
            return Ok(_billAppService.GetDetailBillById(id));
        }
        [HttpDelete]
        [Route("DeleteBill")]
        public IActionResult DeleteBill(int id)
        {
            if (ModelState.IsValid)
            {
                var model = _billAppService.DeleteBill(id);
                return Ok(model);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("IsCheckPayment")]
        public IActionResult IsCheckPayment(int id,bool isPay)
        {
            if (ModelState.IsValid)
            {
                var model = _billAppService.IsCheckPayment(id, isPay);
                return Ok(model);
            }
            return NotFound();
        }
    }
}