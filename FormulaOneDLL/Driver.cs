using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    class Driver
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
            this.driverNumber = driverNumber;
            this.driverName = driverName;
            this.driverSurname = driverSurname;
            this.teamCode = teamCode;
            this.countryCode = countryCode;
            this.winNumber = winNumber;
            this.worldChampionshipsNumber = worldChampionshipsNumber;
            this.img = img;
        }
    }
}
