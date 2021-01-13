using System;
using System.Collections.Generic;
using System.IO;
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

        public List<string> GetTables()
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

        public void Backup(string WORKINGPATH)
        {
            CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security =True";
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [" + WORKINGPATH + "FormulaOne.mdf] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection())
                {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand())
                    {
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = @"BACKUP DATABASE [" + WORKINGPATH + "FormulaOne.mdf] TO DISK='" + WORKINGPATH + @"\prova.bak'";
                        backupcomm.ExecuteNonQuery();
                    }
                    backupConn.Close();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Backup Created Correctly");
            }

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
            }
        }
        public  void ExecuteDropTable(string sqlScriptName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("DROP TABLE IF EXISTS " + sqlScriptName + ";", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table " + sqlScriptName + " is Dropped ");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " -->" + ex.Errors);
            }
            con.Close();
        }



        public  void ExecuteSqlScripts(string sqlScriptName,string WORKINGPATH)
        {
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\t", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\r", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("query", con);
            con.Open();
            int i = 0; int nerr = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Error is in the query number " + i + "\n");
                    Console.WriteLine("Error during Execution : Message" + err.Message);
                    nerr++;
                }
            }
            if (nerr == 0)
            {
                Console.WriteLine("Script " + sqlScriptName + " Executed Without Errors");
            }
            else
            {
                Console.WriteLine("Error verified: "+nerr);
            }
        }
    }
}
