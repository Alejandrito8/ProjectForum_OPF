using System;
using ProjectForum.Data;

namespace ProjectForum.Models;

public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }
    public int? CommentId { get; set; }
    public Comment ParentComment { get; set; }
    public List<Comment> Replies { get; set; } = new List<Comment>();
}