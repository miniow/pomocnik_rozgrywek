using Microsoft.EntityFrameworkCore;
using Pomocnik_Rozgrywek.Data;
using Pomocnik_Rozgrywek.Models;
using Pomocnik_Rozgrywek.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomocnik_Rozgrywek.Repositories
{
    public class PersonRepository : RepositoryBase, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<Person> AddAsync(Person person)
        {
            person.LastUpdated = DateTime.Now;
            await _db.Person.AddAsync(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task<Person> EditAsync(Person person)
        {
            person.LastUpdated = DateTime.Now;
            _db.Person.Entry(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task RemoveAsync(int id)
        {
            var person = await _db.Person.FindAsync(id);
            if (person != null)
            {
                _db.Person.Remove(person);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            var player = await _db.Person.FindAsync(id);
            if (player == null)
            {
                throw new KeyNotFoundException($"Pearson with Id {id} not found.");
            }
            return player;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _db.Person.Include(p=>p.CurrentTeam).ToListAsync();
        }
    }
}
