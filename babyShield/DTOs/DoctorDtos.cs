using babyShield.Models;

namespace babyShield.DTOs
{
    public class DoctorDtos
    {
        public int Id { get; set; }
        public string doctorName { get; set; }
        public long nationalId { get; set; }
        public string specialest { get; set; }
        public long phoneNumber { get; set; }
        public int clinicId { get; set; }
        public List<DoctorAppointment>? DoctorAppointments { get; set; }
    }
}
