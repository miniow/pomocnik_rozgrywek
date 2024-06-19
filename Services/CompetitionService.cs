using Microsoft.IdentityModel.Tokens;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories;
using Pomocnik_Rozgrywek.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepository _competitionRepository;
        private readonly IAreaRepository _areaRepository;
        private readonly ISeasonRepository _seasonRepository;

        public CompetitionService()
        {
            _competitionRepository = new CompetitionRepository();
            _areaRepository = new AreaRepository();
            _seasonRepository = new SeasonRepository();
        }

        public async Task AddToArea(Competition competition, Area area)
        {
            if(area.Competitions.IsNullOrEmpty())
            {
                area.Competitions = new List<Competition>();
            }
            competition.Area = area;
            area.Competitions.Add(competition);
            await _competitionRepository.EditAsync(competition);
            await _areaRepository.EditAsync(area);
        }

        public async Task<Competition> CreateCompetitionAsync(Competition competition)
        {
            return await _competitionRepository.AddAsync(competition);
        }

        public async Task DeleteCompetitionAsync(int id)
        {
            await _competitionRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<Competition>> GetAllCompetitionsAsync()
        {
            return await _competitionRepository.GetAllAsync();
        }

        public async Task<Competition> GetCompetitionByIdAsync(int id)
        {
            return await _competitionRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Season>> GetSeasonsAsync()
        {
            return await _seasonRepository.GetAllAsync();
        }

        public async Task SetCompetitonSeason(Competition competition, Season season)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition));
            if (season == null)
                throw new ArgumentNullException(nameof(season));

            competition.CurrentSeason = season;
            await _competitionRepository.EditAsync(competition);
        }

        public async Task<Competition> UpdateCompetitionAsync(Competition competition)
        {
            if (competition == null)
                throw new ArgumentNullException(nameof(competition));

            return await _competitionRepository.EditAsync(competition);
        }
    }
}
