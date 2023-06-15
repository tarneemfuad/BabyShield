using Microsoft.AspNetCore.Identity;

namespace babyShield.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public long nationalId { get; set; }
}

