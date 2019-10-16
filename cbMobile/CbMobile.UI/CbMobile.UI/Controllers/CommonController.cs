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
    public class CommonController : ControllerBase
    {
        private readonly ICommonAppService _commonAppService;
        public CommonController(ICommonAppService commonAppService)
        {
            _commonAppService = commonAppService;
        }
        [HttpGet]
        [Route("GetYesNoDropdownList")]
        public IActionResult GetYesNoDropdownList()
        {
            var publish = new List<DropDownYesNo> {
                new DropDownYesNo{ Text = "Yes", Value = 1 },
                new DropDownYesNo{ Text = "No", Value=0 },
            };
            return Ok(publish);
        }
    }
}