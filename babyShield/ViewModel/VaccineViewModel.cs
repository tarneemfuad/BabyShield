using babyShield.Models;

namespace babyShield.ViewModel
{
    public class VaccineViewModel
    {
        public List<Vaccine> vaccines { get; set; }
        public List<PatientVaccine> patientVaccine { get; set; }
        public Patient patient { get; set; }
    }
}
