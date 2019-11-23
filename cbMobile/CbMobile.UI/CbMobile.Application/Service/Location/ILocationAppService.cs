using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface ILocationAppService
    {
        IEnumerable<LocationViewModel> GetAllLocation();
        Object AdminGetAllLocation(int page = 1, int pageSize = 10);
        Location GetDetailsLocation(int id);
        bool CreateLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(int id);
     }
}
