using System.ComponentModel.DataAnnotations.Schema;

namespace babyShield.Models
{
    public class prescription
    {
        public int Id { get; set; }
        public int patientId { get; set; }
        [ForeignKey("patientId")]
        public Patient patient { get; set; }
        public string medicalCondition { get; set; }
        public string medication { get; set; }
        public string dosage { get; set; }
        public string frequency { get; set; }
        public DateTime datePrescribed { get; set; }

    }
}
