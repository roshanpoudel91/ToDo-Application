using Domain;
using Microsoft.EntityFrameworkCore;
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
            Console.WriteLine("inside todo docs");
            var todos = databaseContext.ToDos
                .Include(x => x.Categories)
                .Include(x => x.Priorities)
                .Include(x => x.Users)
                .ToList();

            return todos;

        }
    }
}
