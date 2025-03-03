using System;

namespace ProjectForum.Models;

public class Catagory
{
    public int Id {get; set;}
    public string Name {get; set;}
    public List<Post> Posts {get; set;}
}
