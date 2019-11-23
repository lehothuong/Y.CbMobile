using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface IMainColorAppService
    {
        Object GetAllMainColor(int page = 1, int pageSize = 10);
        MainColor GetDetailMainColor(int id);
        bool CreateMainColor(MainColor mainColor);
        bool UpdateMainColor(MainColor mainColor);
        bool DeleteMainColor(int id);
        Object GetListMainColor();
    }
}
