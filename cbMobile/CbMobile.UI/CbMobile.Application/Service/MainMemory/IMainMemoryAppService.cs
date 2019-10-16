using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface IMainMemoryAppService
    {
        Object GetAllMainMemory(int page = 1, int pageSize = 10);
        MainMemory GetDetailMainMemory(int id);
        bool CreateMainMemory(MainMemory mainMemory);
        bool UpdateMainMemory(MainMemory mainMemory);
        bool DeleteMainMemory(int id);
        Object GetListMainMemory();
    }
}
