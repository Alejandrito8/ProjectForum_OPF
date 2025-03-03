using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectForum.Models;

namespace ProjectForum.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ProjectForum(DbContextOptions<ForumDbContext> options) : DbContext(options)
{
    public DbSet<Catagory> Catagories {get; set;}
    public DbSet<Thread> Threads {get; set;}
    public DbSet<Comment> Comments {get; set;}
}

