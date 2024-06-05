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
    public class TeamRepository : RepositoryBase, ITeamRepository
    {
        public TeamRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Team> AddAsync(Team team)
        {
            await _db.Teams.AddAsync(team);
            await _db.SaveChangesAsync();
            return team;
        }

        public async Task<Team> EditAsync(Team team)
        {
            _db.Teams.Update(team);
            await _db.SaveChangesAsync();
            return team;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _db.Teams.ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            var team = await _db.Teams.FindAsync(id);
            if (team == null)
            {
                throw new KeyNotFoundException($"Team with Id {id} not found.");
            }
            return team;
        }

        public async Task RemoveAsync(int id)
        {
            var team = await _db.Teams.FindAsync(id);
            if (team != null)
            {
                _db.Teams.Remove(team);
                await _db.SaveChangesAsync();
            }
        }
    }
}
