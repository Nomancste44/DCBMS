using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.Model.DataBindModel;
using DCBillManagementSystemWebApp.Model.EntityModel;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.DAL
{
    public class TestRequestGateway:CommonGateway
    {
        public List<BindTestNamesInDropdownList> BindAllTestName()
        {
        List<BindTestNamesInDropdownList> testNames = new List<BindTestNamesInDropdownList>();
            string query = "SELECT TestNames.Name, TestNames.Fee FROM TestNames Order by Name;";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    BindTestNamesInDropdownList aTestName = new BindTestNamesInDropdownList();
                    aTestName.TestName = reader["Name"].ToString();
                    aTestName.Fee = Convert.ToDouble(reader["Fee"]);
                    testNames.Add(aTestName);
                }    
                Connection.Close();
            }
            return testNames;
        }

        public bool SavePatientInfo(PatientInfo aPatientInfo)
        {
            string query = "INSERT INTO Patients Values('"+aPatientInfo.Name+"','"+aPatientInfo.Birthday+"','"+aPatientInfo.MobileNumber+"')";
            Command.CommandText = query;
            Connection.Open();
            var rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected > 0;
        }

        public bool IsthisNumberExist(string aNumber)
        {
            string query = "SELECT *FROM Patients WHERE MobileNumber ='" + aNumber + "'";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            bool hasRows = reader.HasRows;
            Connection.Close();
            return hasRows;
        }

        public int GetPatientId(string text)
        {
            int Id = 0;

            string query = "SELECT Id FROM Patients WHERE MobileNumber ='" + text + "';";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Id = Convert.ToInt32(reader["Id"]);
                Connection.Close();
            }

            return Id;
        }

        public List<int> GetAllRequestedTestId(List<ViewRequestTestName> totalRequestedTestNames)
        {
            Connection.Open();
            List<int> alltestId = new List<int>();
            foreach (var aRequestedTestName in totalRequestedTestNames)
            {
                int Id;
                string query = "SELECT Id FROM TestNames WHERE Name='"+aRequestedTestName.Test+"'";
                Command.CommandText = query;
                SqlDataReader reader = Command.ExecuteReader();
                reader.Read();
                Id = Convert.ToInt32(reader["Id"]);
                alltestId.Add(Id);
                reader.Close();
            }
            Connection.Close();
            return alltestId;
           
        }
        public bool SaveTestsInfo(List<int> AllRequestedTestId, int patientId)
        {
            int rowsAffected=0;
            Connection.Open();
            foreach (var aRequestedTestId in AllRequestedTestId)
            {
                string query = "INSERT INTO TestPatient VALUES('"+patientId+"','"+aRequestedTestId+"',GETDATE());";
                Command.CommandText = query;
                rowsAffected = Command.ExecuteNonQuery();
            }
            Connection.Close();
            return rowsAffected > 0;
        }

        public bool SaveCustomerBillInformation(CustomerBillInformation aBillInformation)
        {
            string query = "INSERT INTO BillInformation VALUES('"+aBillInformation.BillNumber+
            "','"+aBillInformation.BillStatus+"',"+aBillInformation.DueDate+",'"
            +aBillInformation.CustomerMobileNumber+"',"+aBillInformation.TotalBillAmount+");";
            Command.CommandText = query;
            Connection.Open();
            var rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected > 0;
        }

        public string GetBillNumber(string mobileNumber)
        {
            string query = "spViewBillNumber '"+mobileNumber+"'";
            Command.CommandText = query;
            Connection.Open();
            var reader = Command.ExecuteReader();
            reader.Read();
            var billNumber = reader["BillNumber"].ToString();
            reader.Close();
            Connection.Close();
            return billNumber;
        }
    }
}