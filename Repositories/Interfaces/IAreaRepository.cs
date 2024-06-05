using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories.Interfaces
{
    public interface IAreaRepository
    {
        Task<Area> AddAsync(Area area);
        Task<Area> EditAsync(Area area);
        Task<IEnumerable<Area>> GetAllAsync();
        Task<Area> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }
}
