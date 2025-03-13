using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectForum.Models;
using ProjectForum.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using ProjectForum.Components.Account.Pages.Manage;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;

namespace ProjectForum.Data
{
    public class PostService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public PostService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<List<Post>> GetPostsByCategory(Category category)
        {
            return await _context.Posts
                .Where(p => p.Category == category)
                .Include(p => p.Comments)
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<Post> CreatePost(Post post)
        {
            if (string.IsNullOrWhiteSpace(post.Title) || string.IsNullOrWhiteSpace(post.Content))
            {
                return null;
            }
            var newPost = new Post
            {
                Title = post.Title,
                Content = post.Content,
                PublishedOn = DateTime.Now,
                UserId = post.UserId,
                Category = post.Category,
                Comments = new List<Comment>()
            };

            _context.Posts.Add(newPost);
            await _context.SaveChangesAsync();

            return newPost;
        }

        public async Task<bool> CanModifyPost(int postId, string userId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return false;
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null && (user.Id == post.UserId || await _userManager.IsInRoleAsync(user, "Admin")))
            {
                return true;
            }

            return false;
        }

        public async Task<bool> DeletePost(int postId, string userId)
        {
            if (!await CanModifyPost(postId, userId))
            {
                return false;
            }

            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return false;
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<bool> CanModifyComment(int commentId, string userId)
        {
            var comment = await _context.Comments.FindAsync(commentId);

            if (comment == null)
            {
                return false; 
            }

            return comment.UserId == userId; 
        }

        public async Task<bool> DeleteComment(int commentId, string userId)
        {
            if (!await CanModifyComment(commentId, userId))
            {
                return false;
            }

            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
            {
                return false; 
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return true; 
        }


public async Task<List<Comment>> GetAllComments()
{
    return await _context.Comments
        .Include(c => c.User)
        .Include(c => c.Post)
        .ToListAsync();
}

        public async Task<bool> AddComment(int postId, string commentContent, string userId)
        {
            if (string.IsNullOrWhiteSpace(commentContent))
            {
                return false;
            }

            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return false;
            }

            var comment = new Comment
            {
                Content = commentContent,
                UserId = userId,
                PostId = postId,
                CreatedAt = DateTime.Now
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return true;
        }

public async Task<bool> LikePost(int postId, string userId)
{
    var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == postId);

    if (post == null)
        return false;

    post.Likes++;

    await _context.SaveChangesAsync();

    return true;
}




    }


}


