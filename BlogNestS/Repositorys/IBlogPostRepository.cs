﻿using BlogNestS.Models;

namespace BlogNestS.Repositorys
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost?> GetAsync(Guid id);

        Task<BlogPost> AddAsync(BlogPost blogPost);
        Task<BlogPost> GetByUrlHandleAsync(string urlHandle);

        Task<BlogPost?> UpdateAsync(BlogPost blogPost);

        Task<BlogPost?> DeleteAsync(Guid id);
    }
}
