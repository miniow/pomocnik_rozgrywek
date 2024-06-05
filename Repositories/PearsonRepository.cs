using Microsoft.EntityFrameworkCore;
using Pomocnik_Rozgrywek.Data;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories
{
    public class PearsonRepository : RepositoryBase, IPearsonRepository
    {
        public PearsonRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Pearson> AddAsync(Pearson pearson)
        {
            await _db.People.AddAsync(pearson);
            await _db.SaveChangesAsync();
            return pearson;
        }

        public async Task<Pearson> EditAsync(Pearson pearson)
        {
            _db.People.Update(pearson);
            await _db.SaveChangesAsync();
            return pearson;
        }

        public async Task RemoveAsync(int id)
        {
            var pearson = await _db.People.FindAsync(id);
            if (pearson != null)
            {
                _db.People.Remove(pearson);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Pearson> GetByIdAsync(int id)
        {
            var pearson = await _db.People.FindAsync(id);
            if (pearson == null)
            {
                throw new KeyNotFoundException($"Pearson with Id {id} not found.");
            }
            return pearson;
        }

        public async Task<IEnumerable<Pearson>> GetAllAsync()
        {
            return await _db.People.ToListAsync();
        }
    }
}
