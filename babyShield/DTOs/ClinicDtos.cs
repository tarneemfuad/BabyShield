using babyShield.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace babyShield.DTOs
{
    public class ClinicDtos
    {
        public int Id { get; set; }
        public string clinicName { get; set; }
        public int managerId { get; set; }
        public int receptionId { get; set; }


    

        public bool isFreaze { get; set; }
    }
}
