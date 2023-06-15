namespace babyShield.DTOs
{
    public class appointmentDtos
    {
        public bool isBooked { get; set; }
        public int DoctorId { get; set; }

        public int? PatientId { get; set; }

        public DateTime dateTime { get; set; }
    }
}
