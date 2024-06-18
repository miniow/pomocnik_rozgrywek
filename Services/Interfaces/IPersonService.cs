using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person> GetPersonByIdAsync(int id);
        Task<IEnumerable<Person>> GetAllPersonAsync();
        Task<Person> CreatePersonAsync(Person player);
        Task<Person> UpdatePersonAsync(Person player);
        Task DeletePersonAsync(int id);
        Task AddToTeam(Person player, Team team);
        Task AppointAsCoach(Person person, Team team);
    }
}
