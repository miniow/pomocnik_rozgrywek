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
        Season GetSeasonById(int id);
        IEnumerable<Season> GetAllSeasons();
        void CreateSeason(Season season);
        void UpdateSeason(Season season);
        void DeleteSeason(int id);
    }
}
