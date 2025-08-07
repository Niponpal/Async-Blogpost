using Microsoft.AspNetCore.Identity;

namespace BlogNestS.Repositorys
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
