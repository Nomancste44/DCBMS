using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.DAL;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.BLL
{
    public class TypeWiseReportManager
    {
        readonly TypeWiseReportGateway _aTypeWiseReportGateway=new TypeWiseReportGateway();
        public List<ViewTypeWiseReport> GetAllReportByTypeWise(string fromDate, string toDate)
        {
            return _aTypeWiseReportGateway.GetAllReportByTypeWise(fromDate, toDate);
        }

        public double GetTotalAmount()
        {
            return _aTypeWiseReportGateway.GetTotalAmount();
        }
    }
}