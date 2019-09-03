using System;
using System.Collections.Generic;
using System.Text;
using CbMobile.Domain.Models;

namespace CbMobile.Application.Service
{
    public interface ISubscribeAppService
    {
        Subscribe PostSubscribe(Subscribe subscribe);
    }
}
