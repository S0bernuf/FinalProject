using FinalProject.BusinessLogic.Dtos;


namespace FinalProject.BusinessLogic.Services.Interfaces
{

    public interface IPersonService
    {

        Task<ServiceResponse<PersonDto>> CreatePersonAsync(int userId, PersonDto dto);
        Task<ServiceResponse<PersonDto>> UpdatePersonAsync(int userId, int personId, PersonDto dto);
        Task<ServiceResponse<PersonDto>> GetPersonByIdAsync(int userId, int personId);
        Task<ServiceResponse<PersonDto>> UpdatePersonNameAsync(int userId, int personId, string firstName, string lastName);
        Task<ServiceResponse<PersonDto>> DeletePersonAsync(int userId, int personId);
    }
}
