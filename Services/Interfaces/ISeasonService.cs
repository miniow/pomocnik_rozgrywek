using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface ISeasonService
    {
        Task<Season> GetSeasonByIdAsync(int id);
        Task<IEnumerable<Season>> GetAllSeasonsAsync();
        Task<Season> CreateSeasonAsync(Season season);
        Task<Season> UpdateSeasonAsync(Season season);
        Task DeleteSeasonAsync(int id);
    }
}
