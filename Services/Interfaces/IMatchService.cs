using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface IMatchService
    {
        Match GetMatchById(int id);
        IEnumerable<Match> GetAllMatches();
        void CreateMatch(Match match);
        void UpdateMatch(Match match);
        void DeleteMatch(int id);
    }
}
