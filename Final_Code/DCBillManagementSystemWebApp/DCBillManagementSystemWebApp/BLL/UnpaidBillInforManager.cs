using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.DAL;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.BLL
{
    public class UnpaidBillInforManager
    {
        readonly UnpaidBillInfoGateway _aUnpaidBillInfoGateway = new UnpaidBillInfoGateway();
        public double GetTotalAmount()
        {
            return _aUnpaidBillInfoGateway.GetTotalAmount();
        }

        public List<ViewUnpaidBillInfo> GetAllUnpaidBillInfo(string fromDate, string toDate)
        {
            return _aUnpaidBillInfoGateway.GetAllUnpaidBillInfo(fromDate, toDate);
        }
    }
}