using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Threading;


namespace FormulaOneConsole
{
    class Program
    {
        /// <summary>
        
        /// </summary>
        public const string WORKINGPATH = @"C:\data\FormulaOne\";  /// Creare una cartella su C:\data--> FormulaOne--> countries.sql
        public const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security =True";
        private static string DB_NAME = @"C:\USERS\RATHORE\DESKTOP\SCUOLA\CSHARP-CODE\BACKUPMDFDB\BACKUPMDFDB\BIN\DEBUG\PROVA.MDF";
        private static string DB_PATH = System.Environment.CurrentDirectory;
        public static string[] sql = { "drivers.sql", "teams.sql", "countries.sql", "circuits.sql", "races.sql" };
        public static string[] database = { "Driver", "Team", "Country", "Circuit", "Race" };

        static void Main(string[] args)
        {
           Console.WriteLine("*** FORMULA ONE - BATCH OPERATIONS ***");
            char scelta;
            do
            {
                Console.WriteLine("\n*** FORMULA ONE  BATCH SCRIPTS ***\n");
                Console.WriteLine("1 -  Create Countries");
                Console.WriteLine("2 -  Create Teams");
                Console.WriteLine("3 -  Create Drivers");
                Console.WriteLine("4 -  Create Circuits");
                Console.WriteLine("5 -  Create Races");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("R -  RESET DB");
                Console.WriteLine("B -  BACKUP");
                Console.WriteLine("S - SHOW TABLE");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("X -  EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch(scelta)
                {
                    case '1':
                        {
                            wait();
                            ExecuteSqlScripts("countries.sql");
                            break;
                        }
                    case '2':
                        {
                            wait();
                            ExecuteSqlScripts("teams.sql");
                            break;
                        }
                    case '3':
                        {
                            wait();
                            ExecuteSqlScripts("drivers.sql");
                            break;
                        }
                    case '4':
                        {
                            wait();
                            ExecuteSqlScripts("circuits.sql");
                            break;
                        }
                    case '5':
                        {
                            wait();
                            ExecuteSqlScripts("races.sql");
                            break;
                        }
                    case 'R':
                    case 'r':
                        {
                            wait();
                            ResetDB();
                            break;
                        }
                    case 'B':
                    case 'b':
                        {
                            wait(); 
                            Backup();
                            break;
                        }
                    case 'S':
                    case 's':
                        {
                            wait();
                            ShowTable();
                            break;
                        }
                    default:
                        if (scelta != 'x' && scelta != 'X') Console.WriteLine("\nUncorrect Choice - Try Again");
                        break;
                }


            } while (scelta !='x' && scelta != 'X');

        }

        private static void ShowTable()
        {
            string key;
            Console.Write("Choose a table : ");
            for(int i= 0 ;i<database.Length;i++)
            {
                Console.Write(" ["+database[i]+"] ");
            }
            Console.Write(" [ALL]");

            key = Console.ReadKey(true).ToString();
            if(key.ToUpper()!="ALL")
            {
                //esegui query(mostra tabella selezionata).
            }
            else
            {
                //esegui query(mostra tutte le tabelle presenti nel database).
            }
            
        } 


        private static void ResetDB()
        {
            //DROP TABLE FUNCTION
            for (int i = 0; i < database.Length; i++)
            {
                ExecuteDropTable(database[i]);
            }
            //RECREATE TABLE FUNCTION
            for (int i = 0; i < sql.Length; i++)
            {
                ExecuteSqlScripts(sql[i]);
            }
            Console.WriteLine("\nRESET DB OK\n\n");
        }

        private static void Backup()
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [" + DB_NAME + "] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

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
                        backupcomm.CommandText = @"BACKUP DATABASE [" + DB_NAME + "] TO DISK='" + DB_PATH + @"\prova.bak'";
                        backupcomm.ExecuteNonQuery();
                    }
                    backupConn.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void wait()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(500);
            }
           Console.Write("\n");
        }
        private static void ExecuteDropTable(string sqlScriptName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("DROP TABLE IF EXISTS " + sqlScriptName+";", con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table "+ sqlScriptName +" is Dropped ");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("ERROR : " + ex.Message + " -->" + ex.Errors);
            }
            con.Close();
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
            }
            if (nerr == 0)
            {
                Console.WriteLine("Script " + sqlScriptName + " Executed Without Errors");
            }
        }
    }
}
