using Pomocnik_Rozgrywek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface ITeamService
    {
        Team GetTeamById(int id);
        IEnumerable<Team> GetAllTeams();
        void CreateTeam(Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(int id);
    }
}
