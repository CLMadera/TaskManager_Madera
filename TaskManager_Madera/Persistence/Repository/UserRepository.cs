using System.Data;
using Dapper;
using Domain.Models;
using Persistence.Context;

namespace Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        
            private readonly IDapperContext _dapperContext;

            public UserRepository(IDapperContext dapperContext)
            {
                _dapperContext = dapperContext;
            }


            public IUser Get(int id)
            {
                using (IDbConnection dbConnection = _dapperContext.CreateConnection())
                {
                    string query = "SELECT * FROM Users WHERE UserId = @Id";
                    return dbConnection.QueryFirstOrDefault<User>(query, new { Id = id });
                }

            }

            public IEnumerable<IUser> GetAll()
            {
                //using (IDbConnection dbConnection = _dapperContext.CreateConnection())
                //{
                //    string query = "SELECT * FROM Users ";
                //    return dbConnection.Query<User>(query);
                //}
                throw new NotImplementedException();
            }

          
            public int Create(IUser model)// czy to zadziała jak dla UserAccount? IUser nie ma wymogu na PasswordHash
            {
                using (IDbConnection dbConnection = _dapperContext.CreateConnection())
                {
                    string query =
                        "INSERT INTO Users (UserId, UserName, Email, Role, CreatedAt, PasswordHash) " +
                        "VALUES ((SELECT ISNULL(MAX(UserId), 0) + 1 FROM Users), @UserName, @Email, @Role, @CreatedAt, @PasswordHash); " +
                        //"SELECT CAST(SCOPE_IDENTITY() as int) ";
                        "SELECT ISNULL(MAX(UserId), 0) FROM Users ";
                    return dbConnection.QuerySingleOrDefault<int>(query, model);
                }

            }

            public bool Update(IUser model)
            {
                throw new NotImplementedException();
            }

            public bool Delete(int id)
            {
                throw new NotImplementedException();
            }
    }
}
