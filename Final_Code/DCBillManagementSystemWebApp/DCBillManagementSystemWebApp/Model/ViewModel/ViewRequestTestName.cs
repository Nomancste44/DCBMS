using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace DCBillManagementSystemWebApp.Model.ViewModel
{
    [Serializable]
    public class ViewRequestTestName
    {
        public int Sl { get; set; }
        public string Test { get; set; }
        public double Fee { get; set; }
    }
}
