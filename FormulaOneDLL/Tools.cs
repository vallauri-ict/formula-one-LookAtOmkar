using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Tools
    {

        private string connection_string;

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
                string sqlcommand = "SELEC * FROM country";
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
    }
}
