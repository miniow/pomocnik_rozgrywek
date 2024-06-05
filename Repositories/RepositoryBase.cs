using Pomocnik_Rozgrywek.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories
{
    public abstract class RepositoryBase
    {
         protected readonly ApplicationDbContext _db;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }
    }
}
