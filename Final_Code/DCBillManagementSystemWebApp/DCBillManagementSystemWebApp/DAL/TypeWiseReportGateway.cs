using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.DAL
{
    public class TypeWiseReportGateway : CommonGateway
    {
        public double TotalAmount = 0;
        public List<ViewTypeWiseReport> GetAllReportByTypeWise(string fromDate, string toDate)
        {
            int counter = 0;
            List<ViewTypeWiseReport> typeWiseReports = new List<ViewTypeWiseReport>();
            string query = "EXEC [spTestTypeWiseReport] '"+fromDate+"','"+toDate+"'";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewTypeWiseReport aTypeWiseReport = new ViewTypeWiseReport();
                    aTypeWiseReport.Sl = ++counter;
                    aTypeWiseReport.TypeName = reader["Name"].ToString();
                    aTypeWiseReport.TotalTest = Convert.ToInt32(reader["TotalTest"]);
                    aTypeWiseReport.TotalAmount = Convert.ToDouble(reader["Total"]);
                    TotalAmount += aTypeWiseReport.TotalAmount;
                    typeWiseReports.Add(aTypeWiseReport);
                }
                reader.Close();
                Connection.Close();
            }
            return typeWiseReports;
        }

        public double GetTotalAmount()
        {
            return TotalAmount;
        }
    }
}