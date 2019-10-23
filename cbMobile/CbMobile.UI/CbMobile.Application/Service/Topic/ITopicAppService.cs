using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface ITopicAppService
    {
        Object AdminGetAllTopic(int page = 1, int pageSize = 10);
        Post GetDetailsTopic(int id);
        bool CreateTopic(Post post);
        bool UpdateTopic(Post post);
        bool DeleteTopic(int id);
    }
}
