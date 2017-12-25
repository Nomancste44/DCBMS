using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Web;

namespace DCBillManagementSystemWebApp.DAL
{
    public class CommonGateway
    {
        public string Cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }

        public CommonGateway()
        {
            Connection = new SqlConnection {ConnectionString = Cs};
            Command = new SqlCommand {Connection = Connection};

        }

    }
}