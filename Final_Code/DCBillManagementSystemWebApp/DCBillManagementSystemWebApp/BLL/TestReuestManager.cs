using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.DAL;
using DCBillManagementSystemWebApp.Model.DataBindModel;
using DCBillManagementSystemWebApp.Model.EntityModel;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.BLL
{
    public class TestReuestManager
    {
        readonly TestRequestGateway _aTestRequestGateway = new TestRequestGateway();
        public List<BindTestNamesInDropdownList> BindAllTestName()
        {
            return _aTestRequestGateway.BindAllTestName();
        }

        public string SavePatientInfo(PatientInfo aPatientInfo)
        {
            if (aPatientInfo.Name != String.Empty && aPatientInfo.MobileNumber != String.Empty)
            {
                if (!_aTestRequestGateway.IsthisNumberExist(aPatientInfo.MobileNumber))
                {
                    return _aTestRequestGateway.SavePatientInfo(aPatientInfo) ?
                     "Saved Sucessfully" : "Save Failed";
                }
                return "This Mobile Number is already Exist";
            }
            return "Please Insert Customer Information Properly";
        }


        public string SaveTestsInfo(List<ViewRequestTestName> totalRequestedTestNames, int patientId)
        {

            return _aTestRequestGateway.SaveTestsInfo(GetAllRequestedTestId(totalRequestedTestNames),
             patientId) ? "Saved Sucessfully" : "Save Failed";
        }

        public int GetPatientId(string text)
        {
            return _aTestRequestGateway.GetPatientId(text);
        }

        public List<int> GetAllRequestedTestId(List<ViewRequestTestName> totalRequestedTestNames)
        {
            return _aTestRequestGateway.GetAllRequestedTestId(totalRequestedTestNames);
        }

        public string SaveCustomerBillInformation(CustomerBillInformation aBillInformation)
        {
          return _aTestRequestGateway.SaveCustomerBillInformation(aBillInformation)?
          "Saved BillInformation":"Save Failed BillInformation";
        }

        public string GetBillNumber(string mobileNumber)
        {
            return _aTestRequestGateway.GetBillNumber(mobileNumber);
        }
    }
}