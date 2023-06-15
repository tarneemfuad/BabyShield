using System.ComponentModel.DataAnnotations.Schema;

namespace babyShield.Models
{
    public class PatientVaccine
    {
        public int Id { get; set; }
        public int vaccineId { get; set; }
        [ForeignKey("vaccineId")]
        public Vaccine vaccine { get; set; }
        public DateTime vaccineDate { get; set; }//تايخ اخذ الطفل للمطعوم
        public double width { get; set; }//الوزن 
        public double hight { get; set; }//الطول
        public int headRadios { get; set; }//محيط رأس الطفل

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
