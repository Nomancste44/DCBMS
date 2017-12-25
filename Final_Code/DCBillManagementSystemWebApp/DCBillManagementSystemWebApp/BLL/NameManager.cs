using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.DAL;
using DCBillManagementSystemWebApp.Model;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.BLL
{
    public class NameManager
    {
        readonly NameGateway _aNameGateway=new NameGateway();
        public string SaveTestName(TestNames testNames)
        {
            if (!_aNameGateway.IsAlredyExist(testNames.TestName))
            {
                return _aNameGateway.SaveTestName(testNames) ? "Saved Successfully" : "Save Failed";
            }

            return "Already Exist";
        }

        public List<ViewTestNames> GetAllName()
        {
            return _aNameGateway.GetAllName();
        }

       
    }
}