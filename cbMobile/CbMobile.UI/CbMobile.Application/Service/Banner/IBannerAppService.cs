using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface IBannerAppService
    {
        IEnumerable<BannerViewModel> GetBannerHome();
        Object GetAllBanner(int page = 1, int pageSize = 10);
        Banner GetDetailsBanner(int id);
        bool CreateBanner(Banner banner);
        bool UpdateBanner(Banner banner);
        bool DeleteBanner(int id);
    }
}
