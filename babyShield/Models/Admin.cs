using babyShield.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace babyShield.Models
{
    public class Admin: IdentityUser
    {
        public int Id { get; set; }
        public string adminName { get; set; }
        public long nationalId { get; set; }
        public ApplicationUser ApplicationUser { get; internal set; }

    }
}
