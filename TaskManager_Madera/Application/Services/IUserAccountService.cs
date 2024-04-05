using Domain.Models;

namespace Application.Services
{
    public interface IUserAccountService
    {
        User? Create(string userName, string email, UserRole role, string passwordHash);
    }
}