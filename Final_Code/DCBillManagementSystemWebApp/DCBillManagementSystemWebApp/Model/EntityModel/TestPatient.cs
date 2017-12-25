using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DCBillManagementSystemWebApp.Model.EntityModel
{
    public class TestPatient
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public DateTime Date { get; set; }
    }
}