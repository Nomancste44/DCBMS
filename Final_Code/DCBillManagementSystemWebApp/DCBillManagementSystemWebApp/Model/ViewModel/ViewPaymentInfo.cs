using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace DCBillManagementSystemWebApp.Model.ViewModel
{
    public class ViewPaymentInfo
    {
        public double TotalAmount { get; set; }
        public string BillStatus { get; set; }
        public string DueDate { get; set; }

    }
}