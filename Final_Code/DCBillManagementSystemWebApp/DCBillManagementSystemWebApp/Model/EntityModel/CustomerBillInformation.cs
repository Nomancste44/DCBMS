using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCBillManagementSystemWebApp.Model.EntityModel
{
    public class CustomerBillInformation
    {
        public string BillNumber { get; set; }
        public string BillStatus { get; set; }
        public string CustomerMobileNumber { get; set; }
        public double TotalBillAmount { get; set; }
        public string DueDate { get; set; }

    }
}