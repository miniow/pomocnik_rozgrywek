using Microsoft.EntityFrameworkCore;
using Pomocnik_Rozgrywek.Data;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories
{
    
    public class MatchRepository : RepositoryBase, IMatchRepository
    {
        public MatchRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Match> AddAsync(Match match)
        {
            await _db.Matches.AddAsync(match);
            await _db.SaveChangesAsync();
            return match;
        }

        public async Task<Match> EditAsync(Match match)
        {
            _db.Matches.Update(match);
            await _db.SaveChangesAsync();
            return match;
        }

        public async Task<IEnumerable<Match>> GetAllAsync()
        {
            return await _db.Matches
         .Include(m => m.HomeTeam)
         .Include(m => m.AwayTeam)
         .Include(m => m.Competition)
         .ToListAsync();
        }

        public async Task<Match> GetByIdAsync(int id)
        {
            var match = await _db.Matches.FindAsync(id);
            if (match == null)
            {
                throw new KeyNotFoundException($"Match with Id {id} not found.");
            }
            return match;
        }

        public async Task RemoveAsync(int id)
        {
            var match = await _db.Matches.FindAsync(id);
            if (match != null)
            {
                _db.Matches.Remove(match);
                await _db.SaveChangesAsync();
            }
        }
    }
}
