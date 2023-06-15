namespace babyShield.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string vaccineName { get; set; }
        public string vaccineCountry { get; set; }
        public int doesNumber { get; set; }
        public int RecomendAge { get; set; }
        public bool disable { get; set; }
    }
}
