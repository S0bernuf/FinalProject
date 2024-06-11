using FinalProject.Database.Entities;
using FinalProject.Database.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Repositories
{
    /*
     * 1. remove unused usings
     * 2. missing delete method
     * 3. calling FindAsync() might not find anything, and app can crash if not catch in try catch block,
     * better approach would be to use FirstOrDefaultAsync() 
     * 4.
     */
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
            return await _context.Persons.FindAsync(personId);
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


    }
}
