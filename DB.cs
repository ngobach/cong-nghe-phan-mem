using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CongNghePhanMem
{
    public class DB
    {
        private const string CONNECTION_STRING = "Server=(local)\\SQLEXPRESS;Database=thuvien;UID=sa;Pwd=123456";
        
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            con.Open();
            return con;
        }

        public static DataTable QueryTable(String query)
        {
            DataTable table = new DataTable();
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
    }
}
