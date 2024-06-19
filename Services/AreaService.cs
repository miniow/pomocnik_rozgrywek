using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories;
using Pomocnik_Rozgrywek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services
{
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _areaRepository;
        private readonly ICompetitionRepository _competitionRepository;

        public AreaService()
        {
            _areaRepository = new AreaRepository();
            _competitionRepository = new CompetitionRepository();
        }

        public async Task AddCompetitionToArea(Competition competition, Area area)
        {
            if (area == null)
            {
                throw new NullReferenceException("Area cannot be null");
            }
            if (competition == null)
            {
                throw new NullReferenceException("Competition cannot be null");
            }

            if (area.Competitions == null)
            {
                area.Competitions = new List<Competition>();
            }

            area.Competitions.Add(competition);
            await _areaRepository.EditAsync(area);

            competition.Area = area;
            await _competitionRepository.EditAsync(competition);

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
            return await _areaRepository.GetRootAsync();
        }

        public async Task<Area> UpdateAreaAsync(Area area)
        {
            return await _areaRepository.EditAsync(area);
        }
        public async Task<Area> CreateChildAreaAsync(Area parentArea, Area childArea)
        {
            if (parentArea == null)
            {
                throw new ArgumentNullException(nameof(parentArea));
            }
            if (childArea == null)
            {
                throw new ArgumentNullException(nameof(childArea));
            }

            childArea.ParentAreaId = parentArea.Id;
            childArea.ParentArea = parentArea.Name;

            if (parentArea.ChildAreas == null)
            {
                parentArea.ChildAreas = new ObservableCollection<Area>();
            }
            parentArea.ChildAreas.Add(childArea);

            // Zapisanie zmian w repozytorium
            await _areaRepository.AddAsync(childArea);
            await _areaRepository.EditAsync(parentArea);

            return childArea;
        }
    }
}
