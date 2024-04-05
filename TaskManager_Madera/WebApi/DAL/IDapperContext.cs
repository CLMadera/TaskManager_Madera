using System.Data;

namespace WebApi.DAL
{
    public interface IDapperContext
    {
        IDbConnection Connection { get; }
    }
}
