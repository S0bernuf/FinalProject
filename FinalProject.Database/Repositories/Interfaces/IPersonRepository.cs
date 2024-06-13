using FinalProject.Database.Entities;


namespace FinalProject.Database.Repositories.Interfaces
{

    public interface IPersonRepository
    {
        Task AddAsync(Person person);
        Task<Person> GetByIdAsync(int personId);
        Task UpdateAsync(Person person);
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        Task<Person> DeletePersonAsync(Person person);
    }
}
