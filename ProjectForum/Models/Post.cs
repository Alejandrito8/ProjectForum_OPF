using System;
using ProjectForum.Data;
namespace ProjectForum.Models;

public class Post
{
public int Id {get; set;}
public string Title {get; set;}
public string Content {get; set;}
public DateTime PublishedOn {get; set;} 

public int UserId {get; set;}
public ApplicationUser User {get; set;}
public Category Category {get; set;}
public List<Comment> Comments {get; set;} 

}
