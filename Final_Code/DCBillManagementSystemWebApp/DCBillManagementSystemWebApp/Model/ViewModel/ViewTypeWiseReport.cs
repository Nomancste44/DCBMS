﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCBillManagementSystemWebApp.Model.ViewModel
{
    public class ViewTypeWiseReport
    {
        public int Sl { get; set; }
        public string TypeName { get; set; }
        public int TotalTest { get; set; }
        public double TotalAmount { get; set; }
        
    }
}