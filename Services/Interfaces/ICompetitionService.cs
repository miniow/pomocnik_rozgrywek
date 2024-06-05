using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface ICompetitionService
    {
        Competition GetCompetitionById(int id);
        IEnumerable<Competition> GetAllCompetitions();
        void CreateCompetition(Competition competition);
        void UpdateCompetition(Competition competition);
        void DeleteCompetition(int id);
    }
}
