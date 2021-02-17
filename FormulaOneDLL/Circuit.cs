namespace FormulaOneDLL
{
    public class Circuit
    {
        private string circuitCode;
        private string name;
        private string country;
        private int length;
        private int laps_number;
        private int turns_number;
        private string first_race_year;
        private string fastest_lap;
        private string full_image;
        private string small_image;

        public Circuit(string circuitCode, string name, string country, int length, int laps_number, int turns_number, string first_race_year, string fastest_lap, string full_image, string small_image)
        {
            this.CircuitCode = circuitCode;
            this.Name = name;
            this.Country = country;
            this.Length = length;
            this.Laps_number = laps_number;
            this.Turns_number = turns_number;
            this.First_race_year = first_race_year;
            this.Fastest_lap = fastest_lap;
            this.Full_image = full_image;
            this.Small_image = small_image;
        }

        public string Country { get => country; set => country = value; }
        public string CircuitCode { get => circuitCode; set => circuitCode = value; }
        public string Name { get => name; set => name = value; }
        public int Length { get => length; set => length = value; }
        public int Laps_number { get => laps_number; set => laps_number = value; }
        public int Turns_number { get => turns_number; set => turns_number = value; }
        public string First_race_year { get => first_race_year; set => first_race_year = value; }
        public string Fastest_lap { get => fastest_lap; set => fastest_lap = value; }
        public string Full_image { get => full_image; set => full_image = value; }
        public string Small_image { get => small_image; set => small_image = value; }
    }
}
