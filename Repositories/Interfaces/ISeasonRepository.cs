using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories.Interfaces
{
    public interface ISeasonRepository
    {
        Task<Season> AddAsync(Season season);
        Task<Season> EditAsync(Season season);
        Task<IEnumerable<Season>> GetAllAsync();
        Task<Season> GetByIdAsync(int id);
        Task RemoveAsync(int id);
    }
}
