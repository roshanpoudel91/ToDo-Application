using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ToDoRepository : Repository<ToDo> , ITodoRepository
    {
        private readonly ApiDataContext databaseContext;
        public ToDoRepository(ApiDataContext databaseContext) : base(databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<ToDo> GetToDos()
        {
            var todos = databaseContext.ToDos
                .ToList();

            return todos;

        }
    }
}
