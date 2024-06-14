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
    public class CoachRepository : RepositoryBase, ICoachRepository
    {
        public CoachRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Coach> AddAsync(Coach coach)
        {
            await _db.Coaches.AddAsync(coach);
            await _db.SaveChangesAsync();
            return coach;
        }

        public async Task<Coach> EditAsync(Coach coach)
        {
            _db.Coaches.Update(coach);
            await _db.SaveChangesAsync();
            return coach;
        }

        public async Task RemoveAsync(int id)
        {
            var coach = await _db.Coaches.FindAsync(id);
            if (coach != null)
            {
                _db.Coaches.Remove(coach);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Coach> GetByIdAsync(int id)
        {
            var coach = await _db.Coaches.FindAsync(id);
            if (coach == null)
            {
                throw new KeyNotFoundException($"Coach with Id {id} not found.");
            }
            return coach;
        }

        public async Task ChangeTeam(Coach coach , Team team)
        {
            coach.CurrentTeam = team;
            await _db.SaveChangesAsync();
        }


        public async Task<IEnumerable<Coach>> GetAllAsync()
        {
            return await _db.Coaches.ToListAsync();
        }
    }
}
