using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface IAccountAppService
    {
        string Authenicate(string userName, string passWord);
        object GetAccountByToken(string token);
        object Logout();
    }
}
