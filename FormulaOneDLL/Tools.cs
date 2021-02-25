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

        public Tools()
        {
            CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\data\FormulaOne\FormulaOne.mdf;Integrated Security =True";
        }

        public string CONNECTION_STRING { get => connection_string; set => connection_string = value; }


        //GET LIST OF STRING
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
                            string IsoCode = reader.GetString(0);
                            string descr = reader.GetString(1);
                            Console.WriteLine("{0} {1}", IsoCode, descr);
                            retVal.Add(IsoCode + " - " + descr);
                        }
                    }
                }
            }

            return retVal;
        }

        //GET OBJECT 
        public List<Country> GetCountriesObject()
        {
            List<Country> retVal = new List<Country>();
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
                            string IsoCode = reader.GetString(0);
                            string descr = reader.GetString(1);
                            Console.WriteLine("{0} {1}", IsoCode, descr);
                            retVal.Add(new Country(IsoCode,descr));
                        }
                    }
                }
            }
            return retVal;
        }
        public List<Races> GetRacesObject()
        {
            List<Races> retVal = new List<Races>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM Race";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id =reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string circuit_id = reader.GetString(2);
                            Console.WriteLine("{0} {1} {2}", Id, name, circuit_id);
                            retVal.Add(new Races(Id, name, circuit_id));
                        }
                    }
                }
            }
            return retVal;
        }
        public List<Circuit> GetCircuitsObject()
        {
            List<Circuit> retVal = new List<Circuit>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM Circuit";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string circuit_code = reader.GetString(0);
                            string name = reader.GetString(1);
                            string country = reader.GetString(2);
                            int _length = Convert.ToInt32(reader.GetString(3));
                            int laps_number = reader.GetInt32(4);
                            int turns_number = reader.GetInt32(5);
                            string first_race_year = reader.GetString(6);
                            string fastest_lap = reader.GetString(7);
                            string full_image = reader.GetString(8);
                            string small_image = reader.GetString(9);


                            retVal.Add(new Circuit(circuit_code, name, country, _length, laps_number, turns_number, first_race_year, fastest_lap, full_image, small_image));
                        }
                    }
                }
            }
            return retVal;
        }
        public List<Driver> GetDriversObject()
        {
            List<Driver> retVal = new List<Driver>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM Driver";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int driverNumber = reader.GetInt32(0);
                            string driverName = reader.GetString(1);
                            string driverSurname = reader.GetString(2);
                            string teamCode = reader.GetString(3);
                            string countryCode = reader.GetString(4);
                            int winNumber = reader.GetInt32(5);
                            int worldChampionshipsNumber = reader.GetInt32(6);
                            string img = reader.GetString(7);

                            retVal.Add(new Driver(driverNumber, driverName, driverSurname, teamCode, countryCode, winNumber, worldChampionshipsNumber, img));
                        }
                    }
                }
            }
            return retVal;
        }
        public List<Team> GetTeamsObject()
        {
            List<Team> retVal = new List<Team>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM Team";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string teamCode = reader.GetString(0);
                            string teamFullName = reader.GetString(1);
                            string teamChief = reader.GetString(2);
                            string teamPowerUnit = reader.GetString(3);
                            int teamFirstEntryYear = reader.GetInt32(4);
                            string teamHQPlace = reader.GetString(5);
                            string nationCode = reader.GetString(6);
                            string logo = reader.GetString(7);
                            string img = reader.GetString(8);

                            retVal.Add(new Team(teamCode, teamFullName, teamChief, teamPowerUnit, teamFirstEntryYear, teamHQPlace, nationCode, logo, img));
                        }
                    }
                }
            }
            return retVal;
        }



        //restituisce un solo oggetto, in base all' id , o paramteri   richiesti
        public List<Country> GetCountry(string isoCode) 
        {
            List<Country> retVal = new List<Country>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM country WHERE countryCode ='"+isoCode+"';";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string IsoCode = reader.GetString(0);
                            string descr = reader.GetString(1);
                            retVal.Add(new Country(IsoCode, descr));
                        }
                    }
                }
            }
            return retVal;
        }
        public List<Circuit> GetCircuit(string circuit_Id)
        {
            List<Circuit> retVal = new List<Circuit>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM Circuit WHERE Circuit.circuit_code = '"+circuit_Id+"';";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string circuit_code = reader.GetString(0);
                            string name = reader.GetString(1);
                            string country = reader.GetString(2);
                            int _length = Convert.ToInt32(reader.GetString(3));
                            int laps_number = reader.GetInt32(4);
                            int turns_number = reader.GetInt32(5);
                            string first_race_year = reader.GetString(6);
                            string fastest_lap = reader.GetString(7);
                            string full_image = reader.GetString(8);
                            string small_image = reader.GetString(9);


                            retVal.Add(new Circuit(circuit_code, name, country, _length, laps_number, turns_number, first_race_year, fastest_lap, full_image, small_image));
                        }
                    }
                }
            }
            return retVal;
        }
        public List<Races> GetRace(int Race_id)
        {
            List<Races> retVal = new List<Races>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "SELECT * FROM Race WHERE Race.Id= "+Race_id+";";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string circuit_id = reader.GetString(2);
                            Console.WriteLine("{0} {1} {2}", Id, name, circuit_id);
                            retVal.Add(new Races(Id, name, circuit_id));
                        }
                    }
                }
            }
            return retVal;
        }
        public List<Driver> GetDriver(int Driver_id,string surname)
        {
            List<Driver> retVal = new List<Driver>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "";
                if ((surname == "") && (Driver_id != 0))
                    sqlcommand = "SELECT * FROM Driver WHERE Driver.driverNumber = " + Driver_id + ";";
                else if ((surname != "") && (Driver_id == 0))
                    sqlcommand = "SELECT * FROM Driver WHERE Driver.driverSurname = '" + surname + "';";
                else
                    sqlcommand = "SELECT * FROM Driver WHERE Driver.driverNumber = "+Driver_id+ " AND  Driver.driverSurname = '" + surname + "';";
                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int driverNumber = reader.GetInt32(0);
                            string driverName = reader.GetString(1);
                            string driverSurname = reader.GetString(2);
                            string teamCode = reader.GetString(3);
                            string countryCode = reader.GetString(4);
                            int winNumber = reader.GetInt32(5);
                            int worldChampionshipsNumber = reader.GetInt32(6);
                            string img = reader.GetString(7);

                            retVal.Add(new Driver(driverNumber, driverName, driverSurname, teamCode, countryCode, winNumber, worldChampionshipsNumber, img));
                        }
                    }
                }
            }
            return retVal;
        }
        public List<Team> GetTeam(string team_id,string team_name)
        {
            List<Team> retVal = new List<Team>();
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                Console.WriteLine("\n Query data example: ");
                Console.WriteLine("========================================");
                string sqlcommand = "";

                if((team_id != "")&&(team_name == ""))
                    sqlcommand = "SELECT * FROM Team WHERE Team.teamCode  ='"+team_id+"';";
                else if((team_id == "")&&(team_name !=""))
                    sqlcommand = "SELECT * FROM Team WHERE Team.teamFullName  ='" + team_name + "';";
                else
                    sqlcommand = "SELECT * FROM Team WHERE Team.teamCode  ='" + team_id + "' AND Team.teamFullName = '" + team_name + "'; ";

                using (SqlCommand command = new SqlCommand(sqlcommand, dbConn))
                {
                    dbConn.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string teamCode = reader.GetString(0);
                            string teamFullName = reader.GetString(1);
                            string teamChief = reader.GetString(2);
                            string teamPowerUnit = reader.GetString(3);
                            int teamFirstEntryYear = reader.GetInt32(4);
                            string teamHQPlace = reader.GetString(5);
                            string nationCode = reader.GetString(6);
                            string logo = reader.GetString(7);
                            string img = reader.GetString(8);

                            retVal.Add(new Team(teamCode, teamFullName, teamChief, teamPowerUnit, teamFirstEntryYear, teamHQPlace, nationCode, logo, img));
                        }
                    }
                }
            }
            return retVal;
        }


        //Restituisce un solo oggetto, in base ad un parametro,diverso dall'id, richiesto
        



        //GET DATATABLES
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


        //EXECUTION COMMANDS
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
