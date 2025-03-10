using Microsoft.EntityFrameworkCore;
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


        public async Task<bool> DeletePost(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                return false; 
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true; 
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

    }


}