using System;

namespace ProjectForum.Models;

public class ApplicationUser
{
  public int Id {get; set;}
  public string FirstName {get; set;}
  public string LastName {get; set;}
  public string Email {get; set;}
  public ICollection<Post> posts {get; set;} //relation to post
  public ICollection<Comment> Comment {get; set;} //relation to Comment
  // Add Rloe(Admin or user)
  // Add list for a post
}
