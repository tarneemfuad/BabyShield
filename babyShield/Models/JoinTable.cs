namespace babyShield.Models
{
    public class JoinTable
    {
        public Doctor doctors { get; set; }
        public DoctorAppointment doctorAppointments { get; set; }
        public Clinic clinics { get; set; }
        public Patient patient { get; set; }

    }
}
