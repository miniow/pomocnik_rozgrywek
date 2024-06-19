using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface IAreaService
    {
        Task<Area> GetAreaByIdAsync(int id);
        Task<Area> GetRoot();
        Task<IEnumerable<Area>> GetAllAreasAsync();
        Task<Area> CreateAreaAsync(Area area);
        Task<Area> UpdateAreaAsync(Area area);
        Task DeleteAreaAsync(int id);
        Task AddCompetitionToArea(Competition competition, Area area);
        Task<Area> CreateChildAreaAsync(Area parentArea, Area childArea);
    }
}
