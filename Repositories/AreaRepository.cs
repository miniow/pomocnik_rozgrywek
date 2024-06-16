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
    public class AreaRepository : RepositoryBase, IAreaRepository
    {
        public AreaRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }

        public async Task<Area> AddAsync(Area area)
        {
            await _db.Areas.AddAsync(area);
            await _db.SaveChangesAsync();
            return area;
        }

        public async Task<Area> EditAsync(Area area)
        {
            _db.Areas.Update(area);
            await _db.SaveChangesAsync();
            return area;
        }

        public async Task<IEnumerable<Area>> GetAllAsync()
        {
            return await _db.Areas.ToListAsync();
        }

        public async Task<Area> GetByIdAsync(int id)
        {
            var area = await _db.Areas.FindAsync(id);
            if (area == null)
            {
                throw new KeyNotFoundException($"Competition with Id {id} not found.");
            }
            return area;
        }

        public async Task<Area> GetRoot()
        {
            return await _db.Areas.FirstOrDefaultAsync(a => a.ParentAreaId == null);
        }

        public async Task RemoveAsync(int id)
        {
            var area = await _db.Areas.FindAsync(id);
            if (area != null)
            {
                _db.Areas.Remove(area);
                await _db.SaveChangesAsync();
            }
        }
    }
}
