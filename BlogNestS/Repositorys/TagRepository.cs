using BlogNestS.Data;
using BlogNestS.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogNestS.Repositorys
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;
        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var data = await _context.Tags.FindAsync(id);
            if (data != null)
            {
                _context.Tags.Remove(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
           var data = await _context.Tags.AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
           var data = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<Tag> GetByUrlHandleAsync(string urlHandle)
        {
           var data = await _context.Tags.AsNoTracking().FirstOrDefaultAsync(x => x.Name == urlHandle);
            return data;
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var data = await _context.Tags.FindAsync(tag.Id);
            if (data != null)
            {
                data.Name = tag.Name;
                data.DisplayName = tag.DisplayName;
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }
    }
}
