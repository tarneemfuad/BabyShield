using babyShield.Models;

namespace babyShield.ViewModel
{
    public class ManagerViewModel
    {

        public List<Patient> patients { get; set; }
        public List<Doctor> doctors { get; set; }
        public List<DoctorAppointment> appointments { get; set; }
        public Manager manager { get; set; }
        public Clinic clinic { get; set; }
        public Reception reception { get; set; }
        public JoinTable fullInfo { get; set; }
    }
}
