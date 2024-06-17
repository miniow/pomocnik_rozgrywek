using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories;
using Pomocnik_Rozgrywek.Repositories.Interfaces;
using Pomocnik_Rozgrywek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        private readonly ICompetitonRepository _competitionRepository;

        public AreaService()
        {
            _areaRepository = new AreaRepository(new Data.ApplicationDbContext());
            _competitionRepository = new CompetitionRepository(new Data.ApplicationDbContext());
        }
        public async Task AddCompetitonToArea(Competition competition, Area area)
        {
            if(area == null) {
                throw new NullReferenceException();
                    }
            if(competition == null)
            {
                throw new NullReferenceException();
            }
           // if(area.Competitions == null)
            //{
            //    throw new NullReferenceException();
           // }
           // area.Competitions.Add(competition);
           // competition.Area = area;
            await _areaRepository.EditAsync(area);
            await _competitionRepository.EditAsync(competition);
            return;
            
        }
        public async Task<Area> CreateAreaAsync(Area area)
        {
            return await _areaRepository.AddAsync(area);
        }

        public async Task DeleteAreaAsync(int id)
        {
            await _areaRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<Area>> GetAllAreasAsync()
        {
            return await _areaRepository.GetAllAsync();
        }

        public async Task<Area> GetAreaByIdAsync(int id)
        {
            return await _areaRepository.GetByIdAsync(id);
        }

        public async Task<Area> GetRoot()
        {
            return await _areaRepository.GetRoot();
        }

        public async Task<Area> UpdateAreaAsync(Area area)
        {
            return await _areaRepository.EditAsync(area);
        }
    }
}
