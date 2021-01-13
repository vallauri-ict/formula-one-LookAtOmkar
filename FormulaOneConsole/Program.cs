using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading;
using FormulaOneDLL;


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
        public static Tools tool = new Tools(CONNECTION_STRING);

        static void Main(string[] args)
        {
           Console.WriteLine("*** FORMULA ONE - BATCH OPERATIONS ***");
            char scelta;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n*** FORMULA ONE  BATCH SCRIPTS ***\n");
                Console.WriteLine("1 -  Create Countries");
                Console.WriteLine("2 -  Create Teams");
                Console.WriteLine("3 -  Create Drivers");
                Console.WriteLine("4 -  Create Circuits");
                Console.WriteLine("5 -  Create Races");
                Console.WriteLine("6 -  Create Constraints");
                Console.WriteLine("7 -  Delete Constraints");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("R -  RESET DB");
                Console.WriteLine("D -  DROP TABLE");
                Console.WriteLine("B -  BACKUP");
                Console.WriteLine("S -  SHOW TABLE");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("X -  EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch(scelta)
                {
                    case '1':
                        {
                            wait();
                            tool.ExecuteSqlScripts("countries.sql",WORKINGPATH);
                            break;
                        }
                    case '2':
                        {
                            wait();
                            tool.ExecuteSqlScripts("teams.sql",WORKINGPATH);
                            break;
                        }
                    case '3':
                        {
                            wait();
                            tool.ExecuteSqlScripts("drivers.sql",WORKINGPATH);
                            break;
                        }
                    case '4':
                        {
                            wait();
                            tool.ExecuteSqlScripts("circuits.sql",WORKINGPATH);
                            break;
                        }
                    case '5':
                        {
                            wait();
                            tool.ExecuteSqlScripts("races.sql",WORKINGPATH);
                            break;
                        }
                    case '6':
                        {
                            wait();
                            tool.ExecuteSqlScripts("SetConstraints.sql",WORKINGPATH);
                            break;
                        }
                    case '7':
                        {
                            wait();
                            break;
                        }
                    case 'R':
                    case 'r':
                        {
                            wait();
                            ResetDB();
                            break;
                        }
                    case 'D':
                    case 'd':
                        {
                            wait();
                            //Ricavare tutte le tabelle che ho nel database 
                            List<string> tables = new List<string>();
                            tables = tool.GetTables();
                            foreach(var table in tables)
                            {
                                Console.WriteLine("--> "+ table );
                            }
                            Console.Write("\n");
                            Console.WriteLine("Choose one table to drop: ");
                            string table_chosen = Console.ReadLine().ToString();  
                            tool.ExecuteDropTable(table_chosen+".sql");
                            break;
                        }
                    case 'B':
                    case 'b':
                        {
                            wait();
                            tool.Backup(WORKINGPATH);
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
            Console.Write("[ALL]");

            key = Console.ReadLine().ToString();
            if(key.ToUpper()!="ALL")
            {
                //esegui query(mostra tabella selezionata).

                DataTable dataTable = new DataTable();
                dataTable = tool.GetDataTable(key);
                foreach(DataRow datarow in dataTable.Rows)
                {
                    Console.WriteLine("_____________________________________________________________________________________________");
                    foreach(var item in datarow.ItemArray)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(item);
                        Console.Write(" | ");
                    }
                    Console.Write("\n");
                }
            }
            else
            {
                //esegui query(mostra tutte le tabelle presenti nel database).
                List<string> tables = new List<string>();
                tables = tool.GetTables();
                foreach(var table in tables)
                {
                    DataTable datatable = new DataTable();
                    datatable = tool.GetDataTable(table);
                    Console.WriteLine("==========="+table+ "===========");
                    foreach(DataRow datarow in datatable.Rows)
                    {
                        Console.WriteLine("________________________________________________________________________________________");
                        foreach(var item in datarow.ItemArray)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(item);
                            Console.Write(" | ");
                        }
                        Console.Write("\n");
                    }

                }

            }
            
        } 


        private static void ResetDB()
        {
            //DROP TABLE FUNCTION
            for (int i = 0; i < database.Length; i++)
            {
                tool.ExecuteDropTable(database[i]);
            }
            //RECREATE TABLE FUNCTION
            for (int i = 0; i < sql.Length; i++)
            {
                tool.ExecuteSqlScripts(sql[i],WORKINGPATH);
            }
            wait();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRESET DB OK\n\n");
        }


        private static void wait()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(".");
                Thread.Sleep(500);
            }
            Console.Write("\n");
        }
   
    }
}
