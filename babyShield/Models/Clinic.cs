using System.ComponentModel.DataAnnotations.Schema;

namespace babyShield.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string clinicName { get; set; }
        public int managerId { get; set; }
        public int receptionId { get; set; }
        [ForeignKey("managerId")]
        public Manager manager { get; set; }
        [ForeignKey("receptionId")]
        public Reception reception { get; set; }

        public bool isFreaze { get; set; }
        public List<Doctor> Doctors { get; set; }


    }
}
