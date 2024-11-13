using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class SqlAccess
    {
        public SqlAccess() 
        { 
            Connect();
        }

        SqlConnection connection = new SqlConnection();
        public bool Connect()
        {
            string cs;
            cs = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VesterlundEfterskole";
            connection.ConnectionString = cs;

            try
            {
                connection.Open();
                connection.Close();
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }
        public DataTable ExcecuteSql(string sql)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close ();
            }
            connection.Open();

            SqlCommand cmd = connection.CreateCommand ();
            cmd.CommandText = sql;

            DataTable table = ExecuteCmd(cmd);

            connection.Close();

            return table;
        }
        private DataTable ExecuteCmd(SqlCommand cmd)
        {
            DataTable table = new DataTable();
            table.Load(cmd.ExecuteReader());
            return table;
        }
    }

}
