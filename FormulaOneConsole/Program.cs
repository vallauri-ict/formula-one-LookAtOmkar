using System;
using System.IO;
using System.Data.SqlClient;

namespace FormulaOneConsole
{
    class Program
    {
        /// <summary>
        
        /// </summary>

        public const string WORKINGPATH = @"C:\data\FormulaOne\";  /// Creare una cartella su C:\data--> FormulaOne--> countries.sql
        public const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security =True";
        static void Main(string[] args)
        {
           Console.WriteLine("*** FORMULA ONE - BATCH OPERATIONS ***");
            char scelta;
            do
            {
                Console.WriteLine("\n*** FORMULA ONE  BATCH SCRIPTS ***\n");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("X EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch(scelta)
                {
                    case '1':
                        {
                            ExecuteSqlScripts("Countries.sql");
                            break;
                        }
                    case '2':
                        {
                            ExecuteSqlScripts("Teams.sql");
                            break;
                        }
                    case '3':
                        {
                            ExecuteSqlScripts("Drivers.sql");
                            break;
                        }
                    default:
                        if (scelta != 'x' && scelta != 'X') Console.WriteLine("\nUncorrect Choice - Try Again");
                        break;
                }


            } while (scelta !='x' && scelta != 'X');

        }

        static void ExecuteSqlScripts(string sqlScriptName)
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
            foreach(var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Errore is in the query number "+ i + "\n");
                    Console.WriteLine("Error during Execution : Message"+ err.Message);
                    nerr++;
                }
                if(nerr ==0)
                {
                    Console.WriteLine("Script Executed Without Errors");
                }
            }

        }
    }
}
