using FinalProject.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task AddAsync(Person person);
        Task<Person> GetByIdAsync(int personId);
        Task UpdateAsync(Person person);
        Task<IEnumerable<Person>> GetAllPersonsAsync();
    }
}
