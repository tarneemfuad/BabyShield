using System.ComponentModel.DataAnnotations.Schema;

namespace babyShield.Models
{
    public class DoctorAppointment
    {

        public int Id { get; set; }
        public bool isBooked { get; set; }
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
        public DateTime dateTime { get; set; }


    }
}
