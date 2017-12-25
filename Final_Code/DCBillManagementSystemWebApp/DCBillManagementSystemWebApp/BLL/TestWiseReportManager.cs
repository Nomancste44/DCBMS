using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.DAL;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.BLL
{
    public class TestWiseReportManager
    {
    readonly TestWiseReportGateway _aTestWiseReportGateway= new TestWiseReportGateway();
        public List<ViewTestWiseReport> GetAllReport(string fromDate, string toDate)
        {   
            return _aTestWiseReportGateway.GetAllReport(fromDate, toDate);
        }

        public double GetTotalAmount()
        {
            return _aTestWiseReportGateway.GetTotalAmount();
        }
    }
}