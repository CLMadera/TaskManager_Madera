using System.Data;

namespace WebApi.DAL
{
    public class DapperContext : IDapperContext
    {
        private readonly IDbConnection _connection;

        public DapperContext(IDbConnection connection)
        {
            _connection = connection;
        }

        public IDbConnection Connection => _connection;
    }
}
