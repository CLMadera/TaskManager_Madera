using System.Data;

namespace DataAccessLibrary.Context;

public interface IDapperContext
{
    IDbConnection CreateConnection();
}
