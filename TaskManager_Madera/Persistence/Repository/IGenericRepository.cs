using System.Collections.Generic;

namespace DataAccessLibrary.Repository
{
    public interface IGenericRepository<TModel>
    {
        TModel Get(int id);
        IEnumerable<TModel> GetAll();
        int Create(TModel model);
        bool Update(TModel model);
        bool Delete(int id);
    }
}