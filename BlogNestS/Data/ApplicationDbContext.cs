using BlogNestS.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogNestS.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<BlogPost> blogPosts { get; set; }
        public object BlogPosts { get; internal set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
