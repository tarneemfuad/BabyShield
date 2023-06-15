using babyShield.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace babyShield.Models
{
    public class Patient: IdentityUser
    {
        public int Id { get; set; }
        public string pateintName { get; set; }
        public long nationalId { get; set; }
        public DateTime birthDate { get; set; }

        public string? Address { get; set; }
        public string? gender { get; set; }
        public string? bloodType { get; set; }
        public int? clinicId { get; set; }
        [ForeignKey("clinicId")]
        public Clinic? clinic { get; set; }
        public int? doctorId { get; set; }
        [ForeignKey("doctorId")]
        public Doctor? doctor { get; set; }

        public List<DoctorAppointment>? Appointments { get; set; }
        public ApplicationUser ApplicationUser { get; internal set; }



    }
}
