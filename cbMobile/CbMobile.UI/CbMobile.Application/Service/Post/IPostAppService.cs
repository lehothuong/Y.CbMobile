using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobileApplication.Service.Post
{
    public interface IPostAppService
    {
        IEnumerable<PostViewModel> GetAboutUs();
    }
}
