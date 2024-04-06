using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Persistence.Repository;

namespace Application.Services
{
    public class UserAccountService : IUserAccountService
    {

        private readonly IUserRepository _repository;
        public UserAccountService(IUserRepository repository)
        {
            _repository = repository;
        }



        public User? Create(string userName, string email, UserRole role, string passwordHash)
        {

            try 
            { 
                var userAccount = UserAccount.Create(userName, email, role, passwordHash);
                var id = _repository.Create(userAccount);
               
                var user =_repository.Get(id);

                return (User?)user;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
