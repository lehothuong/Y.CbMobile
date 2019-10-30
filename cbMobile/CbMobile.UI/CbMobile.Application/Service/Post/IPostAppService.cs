using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface IPostAppService
    {
        IEnumerable<PostViewModel> GetAboutUs();
        IEnumerable<PostViewModel> GetAllNews();
        IEnumerable<PostViewModel> GetNewTechnology();
        IEnumerable<PostViewModel> GetListNewByIdCategory(int id);
        PostViewModel GetDetails(int id);
        Object GetAllPost(int page = 1, int pageSize = 10);
        Post GetDetailsPost(int id);
        bool CreatePost(Post post);
        bool UpdatePost(Post post);
        bool DeletePost(int id);
    }
}
