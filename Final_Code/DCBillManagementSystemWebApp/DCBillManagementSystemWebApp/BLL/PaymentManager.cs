using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.DAL;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.BLL
{
    public class PaymentManager
    {
        readonly PaymentGateway _aPaymentGateway = new PaymentGateway();
        public ViewPaymentInfo GetPaymentInfo(string text)
        {
            return _aPaymentGateway.GetPaymentInfo(text);
        }

        public bool IsThisVaild(string text)
        {
            return _aPaymentGateway.IsThisVaild(text);
        }

        public string PayBill(string patientId)
        {
            return _aPaymentGateway.PayBill(patientId) ? "Paid Successfully" : "Failed to pay";
        }
    }
}