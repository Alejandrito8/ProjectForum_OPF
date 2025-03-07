﻿using Microsoft.EntityFrameworkCore;
using ProjectForum.Models;



namespace ProjectForum.Data
{
    public class PostService
    {
        private readonly ApplicationDbContext _context;
        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetPostsByCategory(Category category)
        {
            return await _context.Posts
                .Where(p => p.Category == category)
                .Include(p => p.Comments)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task CreatePost(Post post)
        {

            var newPost = new Post
            {
                Title = post.Title,
                Content = post.Content,
                PublishedOn = DateTime.Now,
                UserId = post.UserId,
                Category = post.Category,
                Comments = new List<Comment>()
            };

            await _context.SaveChangesAsync();
        }

        public async Task DeletePost(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddComment(int postId, string commentContent, string userId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post != null)
            {
                var comment = new Comment
                {
                    Content = commentContent,
                    UserId = userId,
                    PostId = postId,
                    CreatedAt = DateTime.Now
                };
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
            }
        }
    }


}
//Databas Hanteringen för posts