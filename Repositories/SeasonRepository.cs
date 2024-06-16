 using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Pomocnik_Rozgrywek.Data;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories
{
    public class SeasonRepository : RepositoryBase, ISeasonRepository
    {
        public SeasonRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Season> AddAsync(Season season)
        {
            await _db.AddAsync(season);
            await _db.SaveChangesAsync();
            return season;

        }

        public async Task<Season> EditAsync(Season season)
        {
            _db.Seasons.Update(season);
            await _db.SaveChangesAsync();
            return season;
        }

        public async Task<IEnumerable<Season>> GetAllAsync()
        {
            return await _db.Seasons.ToListAsync();
        }

        public async Task<Season> GetByIdAsync(int id)
        {
            var season = await _db.Seasons.FindAsync(id);
            if(season == null)
            {
                throw new KeyNotFoundException($"Season with Id {id} not found.");
            }
            return season;
        }

        public async Task RemoveAsync(int id)
        {
            var season = await _db.Seasons.FindAsync(id);
            if(season != null)
            {
                _db.Seasons.Remove(season);
                await _db.SaveChangesAsync();
            }
        }
    }
}
