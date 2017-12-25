using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.DAL
{
    public class PaymentGateway:CommonGateway
    {
        public ViewPaymentInfo GetPaymentInfo(string text)
        {
            ViewPaymentInfo aPaymentInfo= new ViewPaymentInfo();
            string query = "SELECT *FROM BillInformation WHERE BillNumber='"+text+"' OR P_MobileNumber='"+text+"';";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            reader.Read();
            aPaymentInfo.BillStatus = reader["BillStatus"].ToString();
            aPaymentInfo.TotalAmount = Convert.ToDouble(reader["TotalAmount"]);
            aPaymentInfo.DueDate = reader["Date"].ToString();    
            Connection.Close();
            return aPaymentInfo;
        }

        public bool IsThisVaild(string text)
        {
            bool hasRows = false;
            string query = "SELECT *FROM BillInformation WHERE BillNumber='" + text + "' OR P_MobileNumber='" + text + "';";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                hasRows = true;
            }
            Connection.Close();
            return hasRows;
        }

        public bool PayBill(string patientId)
        {
            int rowsAffected = 0;
            string query = "UPDATE BillInformation SET BillStatus='Paid' where BillNumber='"+patientId+"' OR P_MobileNumber='"+patientId+"';";
            Command.CommandText = query;
            Connection.Open();
            rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected > 0;
        }
    }
}