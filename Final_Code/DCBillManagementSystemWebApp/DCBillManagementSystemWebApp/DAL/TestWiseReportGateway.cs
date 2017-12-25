using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.DAL
{
    public class TestWiseReportGateway : CommonGateway
    {
        public double TotalAmount = 0;
        public List<ViewTestWiseReport> GetAllReport(string fromDate, string toDate)
        {
            List<ViewTestWiseReport> testWiseReports = new List<ViewTestWiseReport>();
            {
                string query = "EXEC [spTestNameWiseReport] '" + fromDate + "','" + toDate + "';";
                Command.CommandText = query;
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    int counter = 0;

                    while (reader.Read())
                    {
                        ViewTestWiseReport aTestWiseReport = new ViewTestWiseReport();
                        aTestWiseReport.Sl = ++counter;
                        aTestWiseReport.TestName = reader["Name"].ToString();
                        aTestWiseReport.TotalTest = Convert.ToInt32(reader["TotalTest"]);
                        aTestWiseReport.TotalAmount = Convert.ToDouble(reader["Total"]);
                        TotalAmount += aTestWiseReport.TotalAmount;
                        testWiseReports.Add(aTestWiseReport);
                    }
                    reader.Close();
                    Connection.Close();
                }
            }
            return testWiseReports;
        }

        public double GetTotalAmount()
        {
            return TotalAmount;
        }
    }
}