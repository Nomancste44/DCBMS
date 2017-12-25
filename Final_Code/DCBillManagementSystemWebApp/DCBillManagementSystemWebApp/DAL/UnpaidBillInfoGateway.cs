using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.DAL;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.DAL
{
    public class UnpaidBillInfoGateway : CommonGateway
    {
        public double totalUnpaidAmount = 0;
        public double GetTotalAmount()
        {
            return totalUnpaidAmount;
        }

        public List<ViewUnpaidBillInfo> GetAllUnpaidBillInfo(string fromDate, string toDate)
        {
            int counter = 0;
            List<ViewUnpaidBillInfo> unpaidBillInfos = new List<ViewUnpaidBillInfo>();
            string query = "EXEC spUnpaidBill '" + fromDate + "','" + toDate + "';";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewUnpaidBillInfo aUnpaidBillInfo = new ViewUnpaidBillInfo();
                    aUnpaidBillInfo.Sl = ++counter;
                    aUnpaidBillInfo.BillNumber = reader["BillNumber"].ToString();
                    aUnpaidBillInfo.PhoneNumber = reader["MobileNumber"].ToString();
                    aUnpaidBillInfo.CustomerName = reader["Name"].ToString();
                    aUnpaidBillInfo.BillAmount = Convert.ToDouble(reader["TotalAmount"]);
                    totalUnpaidAmount += aUnpaidBillInfo.BillAmount;
                    unpaidBillInfos.Add(aUnpaidBillInfo);
                }
                reader.Close();
                Connection.Close();
            }
            return unpaidBillInfos;
        }
    }
}