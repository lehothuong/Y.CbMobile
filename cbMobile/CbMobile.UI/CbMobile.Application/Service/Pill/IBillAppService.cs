using CbMobile.Domain.Models;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CbMobile.Application.Service
{
    public interface IBillAppService
    {
        #region Admin
        Object AdminGetAllBill(int page = 1, int pageSize = 10);
        bool DeleteBill(int id);
        bool IsCheckPayment(int id, bool isPay);
        Bill GetDetailsBill(int id);
        List<DetailBillViewModel> GetDetailBillById(int id);
        #endregion
        #region UI
        bool PostOrder(OrderViewModel order);
        #endregion
    }
}
