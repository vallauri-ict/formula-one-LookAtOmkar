using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    class Team
    {
        private string teamCode;
        private string teamFullName;
        private string teamChief;
        private string teamPowerUnit;
        private int teamFirstEntryYear;
        private string teamHQPlace;
        private string nationCode;
        private string logo;
        private string img;

        public Team(string teamCode, string teamFullName, string teamChief, string teamPowerUnit, int teamFirstEntryYear, string teamHQPlace, string nationCode, string logo, string img)
        {
            this.teamCode = teamCode;
            this.teamFullName = teamFullName;
            this.teamChief = teamChief;
            this.teamPowerUnit = teamPowerUnit;
            this.teamFirstEntryYear = teamFirstEntryYear;
            this.teamHQPlace = teamHQPlace;
            this.nationCode = nationCode;
            this.logo = logo;
            this.img = img;
        }
    }
}
