using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface ISearchAppService
    {
        IEnumerable<ProductViewModel> Filter(string keyword);
    }
}
