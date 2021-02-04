
namespace FormulaOneDLL
{
    public class Country
    {
        public string IsoCode { get; set; }
        public string Description { get; set; }

        public Country(string isoCode, string description)
        {
            IsoCode = isoCode;
            Description = description;
        }
    }
}
