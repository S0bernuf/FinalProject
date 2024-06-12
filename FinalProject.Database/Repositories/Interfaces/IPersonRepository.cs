using FinalProject.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Database.Repositories.Interfaces
{
    /*
     * 1.remove not used usings
     * 2. delete method missing
     */
    public interface IPersonRepository
    {
        Task AddAsync(Person person);
        Task<Person> GetByIdAsync(int personId);
        Task UpdateAsync(Person person);
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        Task<Person> DeletePersonAsync(Person person);
    }
}
