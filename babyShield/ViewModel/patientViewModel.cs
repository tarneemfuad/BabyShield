using babyShield.Models;

namespace babyShield.ViewModel
{
    public class patientViewModel
    {
        public Patient Patient { get; set; }
        public List<Clinic> clinics { get; set; }
        public List<DoctorAppointment> doctorAppointments { get; set; }
        public List<Doctor> doctors { get; set; }
        public List<prescription> prescription { get; set; }
        public List<PatientVaccine> vaccine { get; set; }
        public Clinic clinic { get; set; }

    }
}
