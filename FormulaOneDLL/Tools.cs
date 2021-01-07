using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Tools
    {

        private string connection_string;
        private DataTable datatable;

        public Tools(string cONNECTION_STRING)
        {
           CONNECTION_STRING = cONNECTION_STRING;
        }

        public string CONNECTION_STRING { get => connection_string; set => connection_string = value; }

        public List<string> GetCountries()
        {
            List<string> retVal = new List<string>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM country";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string IsCode = reader.GetString(0);
                            string descr = reader.GetString(1);
                            Console.WriteLine("{0} {1}", IsCode, descr);
                            retVal.Add(IsCode + " - " + descr);
                        }
                    }
                }
            }

            return retVal;
        }

        public DataTable GetDataTable(string table)
        {
            datatable = new DataTable(); 
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            string sql = "SELECT * FROM "+table;
            SqlCommand cmd = new SqlCommand(sql,con);
            con.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(datatable);
            con.Close();
            da.Dispose();

            return datatable;
        }

        public List<string> ShowTable()
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                DataTable schema = con.GetSchema("Tables");
                List<string> TableNames = new List<string>();
                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                return TableNames;
            }
        }
    }
}
