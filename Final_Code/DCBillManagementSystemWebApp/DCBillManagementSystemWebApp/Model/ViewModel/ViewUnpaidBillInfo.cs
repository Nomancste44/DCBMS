using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCBillManagementSystemWebApp.Model.ViewModel
{
    public class ViewUnpaidBillInfo
    {
        public int Sl { get; set; }
        public string BillNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerName { get; set; }
        public double BillAmount { get; set; }
    }
}