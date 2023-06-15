using babyShield.Models;

namespace babyShield.ViewModel
{
    public class DoctorViewModel
    {
        public Doctor doctor { get; set; }
        public List<Patient> patients { get; set; }
        public List<DoctorAppointment> appointments { get; set; }
        public List<Clinic> clinics { get; set; }
        public  Clinic clinic { get; set; }

    }
}
