using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DCBillManagementSystemWebApp.Model;

namespace DCBillManagementSystemWebApp.DAL
{
    public class TypeGateway : CommonGateway
    {
        public bool SaveTypeName(string atype)
        {
            string query = "INSERT INTO TestTypes Values('" + atype + "')";
                Command.CommandText = query;
                Connection.Open();
                var rowsAffected = Command.ExecuteNonQuery();
                Connection.Close();
            return rowsAffected > 0;
        }

        public bool IsExistTestType(string aType)
        {
            string query = "SELECT *FROM TestTypes WHERE Name='" + aType + "'";
                Command.CommandText = query;
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                bool hasRows= reader.HasRows;
                Connection.Close();
                return hasRows;
            
        }

        public List<TestTypes> GetAll()
        {
            List<TestTypes> testTypes = new List<TestTypes>();
            string query = "SELECT *FROM TestTypes";
                Command.CommandText = query;
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    int count=0;
                    while (reader.Read())
                    {
                        TestTypes aTestType = new TestTypes();
                        aTestType.Sl = ++count;
                        aTestType.TestType = reader["Name"].ToString();
                        testTypes.Add(aTestType);
                    }
                    Connection.Close();
                }
            return testTypes;
        }

        public List<TestTypes> GetAllTestType()
        {
            List<TestTypes> testTypes = new List<TestTypes>();
            string query = "SELECT *FROM TestTypes";
            Command.CommandText = query;
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                int count = 0;
                while (reader.Read())
                {
                    TestTypes aTestType = new TestTypes();
                    aTestType.Sl = Convert.ToInt32(reader["Id"]);
                    aTestType.TestType = reader["Name"].ToString();
                    testTypes.Add(aTestType);
                }
                Connection.Close();
            }
            return testTypes;
        }

    }
}