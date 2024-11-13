using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd_2_boch
{
    internal class Class1
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-2I7BPD1;Initial Catalog = lil;Integrated Security = True");


        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed) { sqlConnection.Open(); }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open) { sqlConnection.Close(); }
        }
        public SqlConnection GetConnection() { return sqlConnection; }
    }
}
