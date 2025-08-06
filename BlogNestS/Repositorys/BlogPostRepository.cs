using BlogNestS.Data;
using BlogNestS.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogNestS.Repositorys
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly ApplicationDbContext _context;

        public BlogPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await _context.blogPosts.AddAsync(blogPost);
            await _context.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var data = await  _context.blogPosts.FindAsync(id);
            if (data != null)
            {
                _context.blogPosts.Remove(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
           var data = await _context.blogPosts.AsNoTracking().ToListAsync();  
            return data;
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
            var data = await _context.blogPosts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return  data;

        }

        public async Task<BlogPost> GetByUrlHandleAsync(string urlHandle)
        {
            var data = await _context.blogPosts.Include(x => x.Id).FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
            return data;
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
            var data = await _context.blogPosts.FindAsync(blogPost.Id);

            if(data != null)
            {
                data.Id = blogPost.Id;
                data.Heading = blogPost.Heading;
                data.Author = blogPost.Author;
                data.PageTitle = blogPost.PageTitle;
                data.ShortDescription = blogPost.ShortDescription;
                data.UrlHandle = blogPost.UrlHandle;
                data.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                data.Visible = blogPost.Visible;
                data.PublishedDate = blogPost.PublishedDate;
                data.Content = blogPost.Content;
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }
    }
}
