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
    public class CompetitionRepository : RepositoryBase, ICompetitonRepository
    {
        public CompetitionRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Competition> AddAsync(Competition competition)
        {

            await _db.Competitions.AddAsync(competition);
             await _db.SaveChangesAsync();
            return competition;
        }

        public async Task<Competition> EditAsync(Competition competition)
        {
            var existingCompetition = await _db.Competitions.FindAsync(competition.Id);
            if (existingCompetition != null)
            {
                _db.Entry(existingCompetition).CurrentValues.SetValues(competition);
                await _db.SaveChangesAsync();
            }
            return competition;
        }

        public async Task<IEnumerable<Competition>> GetAllAsync()
        {
            return await _db.Competitions.AsNoTracking().Include(a=>a.Area).ToListAsync();
        }

        public async Task<IEnumerable<Team>> GetAllTeams(Competition competition)
        {
            var teams = await _db.Teams.AsNoTracking().Include(t=>t.RunningCompetitions).ToListAsync();
            var selecteList = new List<Team>();
            foreach (var team in teams)
            {
                if(team.RunningCompetitions != null)
                {
                    if (team.RunningCompetitions.Contains(competition))
                    {
                        selecteList.Add(team);
                    }
                }
            }
            return selecteList;
        }

        public async Task<Competition> GetByIdAsync(int id)
        {
            var competition = await _db.Competitions.AsNoTracking().Include(a=>a.Teams).FirstOrDefaultAsync(c => c.Id == id);
            if (competition == null)
            {
                throw new KeyNotFoundException($"Competition with Id {id} not found.");
            }
            return competition;
        }

        public async Task<int> GetNumberOfTeamsInCompetitonAsync(Competition competiton)
        {
            return await _db.Competitions.Where(c=> c.Id ==  competiton.Id).SelectMany(c=>c.Teams).CountAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var competition = await _db.Competitions.FindAsync(id);
            if (competition != null)
            {
                _db.Competitions.Remove(competition);
                await _db.SaveChangesAsync();
            }
        }
        public void AttachEntity(Competition competition)
        {
            if (_db.Entry(competition).State == EntityState.Detached)
            {
                _db.Competitions.Attach(competition);
            }
        }
    }
}
