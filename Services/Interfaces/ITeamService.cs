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
        Task<IEnumerable<Person>> GetTeamPlayersAsync(int teamId);
        Task AddPlayerToTeamAsync(Team team, Person pearson);
        Task AddCoachToTeamAsync(Team team, Person pearson);
        Task RemoveCoachFromTeamAsync(Team team);
        Task RemovePlayerFromTeamAsync(Team team, Person pearson);

    }
}
//interakcje między uczestnikami, którzy podejmują decyzje,
//ryzyko przy podejmowaniu decyzji 
//strategie 
//psychologia decyzji
//kto wygrywa kiedy wygrywa dlaczego wygrywaprzy zmianie nagród i procentach błędów