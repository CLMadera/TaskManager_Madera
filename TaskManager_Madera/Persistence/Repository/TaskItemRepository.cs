using Domain.Models;
using Domain.Dto;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Persistence.Repository
{
    internal class TaskItemRepository
    {
        private readonly IDapperContext _dapperContext;

        public TaskItemRepository(IDapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }


        public TaskItem Get(int id)
        {
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
            {
                string query = "SELECT * FROM Tasks WHERE TaskId = @Id";
                return dbConnection.QueryFirstOrDefault<TaskItem>(query, new { Id = id });
            }
        }

        public IEnumerable<TaskItem> GetAll()
        {
            throw new NotImplementedException();
        }


        public int Create(TaskItem model)
        {
            using (IDbConnection dbConnection = _dapperContext.CreateConnection())
            {
                string query =
                    "INSERT INTO Tasks (TaskId, ProjectId, Title, Description, Priority, Status, AssignedTo, CreatedBy, CreatedAt, DueDate, ModifiedBy, ModifiedAt) " +
                    "VALUES (@TaskId, @ProjectId, @Title, @Description, @Priority, @Status, @AssignedTo, @CreatedBy, @CreatedAt, @DueDate, @ModifiedBy, @ModifiedAt); " +
                    "SELECT CAST(SCOPE_IDENTITY() as int) ";
                return dbConnection.QuerySingleOrDefault<int>(query, model);
            }

        }

        public bool Update(TaskItem model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
