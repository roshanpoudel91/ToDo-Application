using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PriorityRepository : Repository<Priority> , IPriorityRepository
    {
        private readonly ApiDataContext databaseContext;

        public PriorityRepository(ApiDataContext databaseContext) : base (databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Priority> GetPriorities()
        {
            var priorities = databaseContext.Priorities
                .ToList();

            return priorities;

        }
    }
}
