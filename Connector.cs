using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gladiaddi
{
    class Connector
    {
        public SqlConnection connection = new SqlConnection();
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Gladiaddi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public SqlCommandBuilder commandBuilder = new SqlCommandBuilder();
        public SqlDataAdapter adapter = new SqlDataAdapter();
        Connector()
        {
            
        }

        public void LoadEntries()
        {
            
            connection.ConnectionString = connectionString;
            connection.Open();
            adapter = new SqlDataAdapter("select * from Saves", connection);
            DataTable table = new DataTable();
            adapter.Fill(table);



        }
    }
}
