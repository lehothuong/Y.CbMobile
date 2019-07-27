using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service.Post
{
    public interface IPostAppService
    {
        IEnumerable<PostViewModel> GetAboutUs();
        IEnumerable<PostViewModel> GetAllNews();
    }
}
