using babyShield.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace babyShield.Models
{
    public class Doctor: IdentityUser
    {
        public int Id { get; set; }
        public string doctorName { get; set; }
        public long nationalId { get; set; }
        public string specialest { get; set; }
        public int clinicId { get; set; }

        [ForeignKey("clinicId")]
        public Clinic clinic { get; set; }



        public List<DoctorAppointment>? DoctorAppointments { get; set; }
        public ApplicationUser ApplicationUser { get; internal set; }

    }
}
