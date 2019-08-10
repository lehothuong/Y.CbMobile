using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service.Location
{
    public interface ILocationAppService
    {
        IEnumerable<LocationViewModel> GetAllLocation();
     }
}
