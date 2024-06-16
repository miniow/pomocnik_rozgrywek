using Pomocnik_Rozgrywek.Data;
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
    public class SeasonService : ISeasonService
    {
        private readonly ISeasonRepository _seasonRepository;
        public SeasonService() {
            _seasonRepository = new SeasonRepository(new Data.ApplicationDbContext());
        }
        public async Task<Season> CreateSeasonAsync(Season season)
        {
            return await _seasonRepository.AddAsync(season);
        }

        public async Task DeleteSeasonAsync(int id)
        {
            await _seasonRepository.RemoveAsync(id);
        }

        public async Task<IEnumerable<Season>> GetAllSeasonsAsync()
        {
            return await _seasonRepository.GetAllAsync();
        }

        public async Task<Season> GetSeasonByIdAsync(int id)
        {
            return await _seasonRepository.GetByIdAsync(id);
        }

        public async Task<Season> UpdateSeasonAsync(Season season)
        {
            return await _seasonRepository.EditAsync(season);
        }
    }
}
