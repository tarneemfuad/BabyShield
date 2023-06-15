namespace babyShield.DTOs
{
    public class prescriptionDtos
    {
        public int Id { get; set; }
        public int patientId { get; set; }
        public string medicalCondition { get; set; }
        public string medication { get; set; }
        public string dosage { get; set; }
        public string frequency { get; set; }
    }
}
