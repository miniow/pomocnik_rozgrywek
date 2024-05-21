using Microsoft.EntityFrameworkCore;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories
{
    public class CompetitionRepository : RepositoryBase, ICompetitonRepository
    {
        public async Task<Competition> AddAsync(Competition competition)
        {
            await _db.Tournaments.AddAsync(competition);
            await _db.SaveChangesAsync();
            return competition;
        }

        public async Task<Competition> EditAsync(Competition competition)
        {
            _db.Tournaments.Update(competition);
            await _db.SaveChangesAsync();
            return competition;
        }

        public async Task<IEnumerable<Competition>> GetAllAsync()
        {
            return await _db.Tournaments.ToListAsync();
        }

        public async Task<Competition> GetByIdAsync(int id)
        {
            var competition = await _db.Tournaments.FindAsync(id);
            if (competition == null)
            {
                throw new KeyNotFoundException($"Competition with Id {id} not found.");
            }
            return competition;
        }

        public async Task RemoveAsync(int id)
        {
            var competition = await _db.Tournaments.FindAsync(id);
            if (competition != null)
            {
                _db.Tournaments.Remove(competition);
                await _db.SaveChangesAsync();
            }
        }
    }
}
