using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class Team
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
            this.TeamCode = teamCode;
            this.TeamFullName = teamFullName;
            this.TeamChief = teamChief;
            this.TeamPowerUnit = teamPowerUnit;
            this.TeamFirstEntryYear = teamFirstEntryYear;
            this.TeamHQPlace = teamHQPlace;
            this.NationCode = nationCode;
            this.Logo = logo;
            this.Img = img;
        }

        public string TeamCode { get => teamCode; set => teamCode = value; }
        public string TeamFullName { get => teamFullName; set => teamFullName = value; }
        public string TeamChief { get => teamChief; set => teamChief = value; }
        public string TeamPowerUnit { get => teamPowerUnit; set => teamPowerUnit = value; }
        public int TeamFirstEntryYear { get => teamFirstEntryYear; set => teamFirstEntryYear = value; }
        public string TeamHQPlace { get => teamHQPlace; set => teamHQPlace = value; }
        public string NationCode { get => nationCode; set => nationCode = value; }
        public string Logo { get => logo; set => logo = value; }
        public string Img { get => img; set => img = value; }
    }
}
