using Domain.Models;

namespace Persistence.Repository
{
    public interface IUserRepository : IGenericRepository<IUser>
    {
        Task<User?> Authenticate(string  userName, string password);
        
    }
}
