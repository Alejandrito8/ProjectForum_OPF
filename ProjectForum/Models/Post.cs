using System;
using ProjectForum.Data;
using ProjectForum.Models;
using Microsoft.EntityFrameworkCore;
namespace ProjectForum.Models;


public class Post
{
public int Id {get; set;}
public string Title {get; set;}
public string Content {get; set;}
public DateTime PublishedOn {get; set;} 
public string? UserId {get; set;}
public ApplicationUser User {get; set;}
public Category Category {get; set;}
public int Likes { get; set; } = 0;
public List<Comment> Comments {get; set;} = new List<Comment>();

}