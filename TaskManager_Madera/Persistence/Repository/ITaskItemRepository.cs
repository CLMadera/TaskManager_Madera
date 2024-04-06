using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Persistence.Repository
{
    internal interface ITaskItemRepository : IGenericRepository<TaskItem>
    {
        TaskItem Get(int id);
        IEnumerable<TaskItem> GetAll();
        int Create(TaskItem model);
        bool Update(TaskItem model);
        bool Delete(int id);
    }
}
