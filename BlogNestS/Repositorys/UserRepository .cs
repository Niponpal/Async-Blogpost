using BlogNestS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogNestS.Repositorys
{
    public class UserRepository: IUserRepository
    {
        private readonly AuthDbContext _dbContext;

        public UserRepository(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<IdentityUser>> GetAll()
        {
            var users = await _dbContext.Users.ToListAsync();
            var superAdmin = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == "superadmin@bloggie.com");
            if (superAdmin != null)
            {
                users.Remove(superAdmin);
            }
            return users;
        }
    }
}
