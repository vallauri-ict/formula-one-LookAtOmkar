
namespace FormulaOneDLL
{
    public class Races
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Circuit_id { get; set; }
        public Races(int id, string name, string circuit_id)
        {
            this.Id = id;
            this.Name = name;
            this.Circuit_id = circuit_id;
        }

    }
}
