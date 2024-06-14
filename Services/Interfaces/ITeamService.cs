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
        Task<Team> GetTeamByIdAsync(int id);
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        Task<Team> CreateTeamAsync(Team team);
        Task<Team> UpdateTeamAsync(Team team);
        Task DeleteTeamAsync(int id);
        Task<IEnumerable<Player>> GetTeamPlayersAsync(int teamId);
        Task AddPlayerToTeamAsync(Team team, Player pearson);
        Task AddStafmenToTeamAsync(Team team, Player pearson);
        Task AddCoachToTeamAsync(Team team, Player pearson);
        Task RemoveCoachFromTeamAsync(Team team);
        Task RemovePlayerFromTeamAsync(Team team, Player pearson);
        Task GetMatchStatistic(Team team);
        
    }
}
