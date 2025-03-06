using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectForum.Models;

namespace ProjectForum.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comment { get; set; }
    }
};

