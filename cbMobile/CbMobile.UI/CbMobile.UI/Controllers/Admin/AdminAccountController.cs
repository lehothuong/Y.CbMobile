using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CbMobile.Application.Service;
using CbMobile.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CbMobile.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAccountController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;
        public AdminAccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Authenticate")]
        public IActionResult Authenicate([FromBody]Account accountParam)
        {
            var user = _accountAppService.Authenicate(accountParam.Username, accountParam.Password);
            if(user == null)
            {
                return BadRequest(new { message = "Username or Password is incorrect" });
            }
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetAccountByToken(string token)
        {
            var users = _accountAppService.GetAccountByToken(token);
            return Ok(users);
        }
    }
}