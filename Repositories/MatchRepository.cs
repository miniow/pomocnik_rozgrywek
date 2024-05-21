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
    public class MatchRepository : RepositoryBase, IMatchRepository
    {
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
            return await _db.Matches.ToListAsync();
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
