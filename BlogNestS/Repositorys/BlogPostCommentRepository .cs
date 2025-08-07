using BlogNestS.Data;
using BlogNestS.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogNestS.Repositorys
{
    public class BlogPostCommentRepository: IBlogPostCommentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BlogPostCommentRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment comment)
        {
            await _dbContext.AddAsync(comment);
            await _dbContext.SaveChangesAsync();
            return comment;
        }

        //public Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            var data = await _dbContext.BlogPostsComment.Where(x => x.BlogPostId == blogPostId).ToListAsync();
            return data;
        }
    }
}
