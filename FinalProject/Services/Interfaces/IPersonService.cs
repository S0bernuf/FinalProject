using FinalProject.BusinessLogic.Dtos;


namespace FinalProject.BusinessLogic.Services.Interfaces
{
    /*
     * 1. remove not used usings -DONE
     */
    public interface IPersonService
    {
        //Sutvarkyti pagal koki modeli kaip teisingai turi buti pakeistas PersonDto
        Task<ServiceResponse<PersonDto>> CreatePersonAsync(int userId, PersonDto dto);
        Task<ServiceResponse<PersonDto>> UpdatePersonAsync(int userId, int personId, PersonDto dto);
        Task<ServiceResponse<PersonDto>> GetPersonByIdAsync(int userId, int personId);
        Task<ServiceResponse<PersonDto>> UpdatePersonNameAsync(int userId, int personId, string firstName, string lastName);
    }
}
