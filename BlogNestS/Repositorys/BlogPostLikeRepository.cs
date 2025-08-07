using BlogNestS.Data;
using BlogNestS.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogNestS.Repositorys
{
    public class BlogPostLikeRepository: IBlogPostLikeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public BlogPostLikeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await _dbContext.BlogPostsLikes.AddAsync(blogPostLike);
            await _dbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await _dbContext.BlogPostsLikes.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
            return await _dbContext.BlogPostsLikes.CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
