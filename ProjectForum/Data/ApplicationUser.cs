using Microsoft.AspNetCore.Identity;
namespace ProjectForum.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? Handle { get; set; }

    }
}
