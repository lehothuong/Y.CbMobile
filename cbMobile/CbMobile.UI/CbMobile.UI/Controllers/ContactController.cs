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
    public class ContactController : ControllerBase
    {
        private readonly IContactAppService _contactAppService;
        public ContactController(IContactAppService contactAppService)
        {
            _contactAppService = contactAppService;
        }
        [HttpPost]
        [Route("PostContact")]
        public ActionResult PostContact([FromBody]Contact contact)
        {
            if (ModelState.IsValid)
            {
                var model =  _contactAppService.PostContact(contact);
                return NoContent();
            }
            return NotFound();
        }
    }
}