using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Driver
    {
        private int driverNumber;
        private string driverName;
        private string driverSurname;
        private string teamCode;
        private string countryCode;
        private int winNumber;
        private int worldChampionshipsNumber;
        private string img;

        public Driver(int driverNumber, string driverName, string driverSurname, string teamCode, string countryCode, int winNumber, int worldChampionshipsNumber, string img)
        {
            this.DriverNumber = driverNumber;
            this.DriverName = driverName;
            this.DriverSurname = driverSurname;
            this.TeamCode = teamCode;
            this.CountryCode = countryCode;
            this.WinNumber = winNumber;
            this.WorldChampionshipsNumber = worldChampionshipsNumber;
            this.Img = img;
        }

        public int DriverNumber { get => driverNumber; set => driverNumber = value; }
        public string DriverName { get => driverName; set => driverName = value; }
        public string DriverSurname { get => driverSurname; set => driverSurname = value; }
        public string TeamCode { get => teamCode; set => teamCode = value; }
        public string CountryCode { get => countryCode; set => countryCode = value; }
        public int WinNumber { get => winNumber; set => winNumber = value; }
        public int WorldChampionshipsNumber { get => worldChampionshipsNumber; set => worldChampionshipsNumber = value; }
        public string Img { get => img; set => img = value; }
    }
}
