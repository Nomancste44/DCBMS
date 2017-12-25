using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DCBillManagementSystemWebApp.Model;
using DCBillManagementSystemWebApp.Model.ViewModel;

namespace DCBillManagementSystemWebApp.DAL
{
    public class NameGateway:CommonGateway
    {
        public bool SaveTestName(TestNames testNames)
        {

            string query = "INSERT INTO TestNames Values('" + testNames.TestName + "','" + testNames.Fee + "','" + testNames.TestTypeId + "')";
            Command.CommandText = query;
            Connection.Open();
            var rowsAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected > 0;

        }

        public List<ViewTestNames> GetAllName()
        {

            List<ViewTestNames> testNames = new List<ViewTestNames>();
            string query = "SELECT *FROM VW_TestNames";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                int count = 0;
                while (reader.Read())
                {
                    ViewTestNames aTestName = new ViewTestNames();
                    aTestName.Sl = ++count;
                    aTestName.TestName = reader["Name"].ToString();
                    aTestName.Fee = Convert.ToDouble(reader["Fee"]);
                    aTestName.TestType = reader["Type"].ToString();
                    testNames.Add(aTestName);

                }
                Connection.Close();
            }
            return testNames;
        }

        public bool IsAlredyExist(string testName)
        {

            string query = "SELECT *FROM TestNames WHERE Name='" + testName + "'";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            bool hasRows = reader.HasRows;
            Connection.Close();
            return hasRows;
        }
    }
}