using System;
using ProjectForum.Data;

namespace ProjectForum.Models;

public class Comment
{
public int Id {get; set;}
public string Content {get; set;}
public DateTime CreatedAt {get; set;}

public int PostId {get; set;}
public Post Post {get; set;}

public int UserId {get; set;}
public ApplicationUser User {get; set;}
public List<Comment> Comments {get; set;} // ?? comment on a comment and how Do i connect them
}
