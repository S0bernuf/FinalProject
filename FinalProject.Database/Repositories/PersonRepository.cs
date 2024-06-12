using FinalProject.Database.Entities;
using FinalProject.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Database.Repositories
{

    public class PersonRepository : IPersonRepository
    {
        private readonly FinalProjectDbContext _context;

        public PersonRepository(FinalProjectDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(int personId)
        {

            return await _context.Persons.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Person person)
        {
            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> DeletePersonAsync(Person person)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return person;
        }


    }
}
