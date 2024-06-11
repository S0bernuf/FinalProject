using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.BusinessLogic.Dtos;
using FinalProject.Database.Entities;

namespace FinalProject.BusinessLogic.Services.Interfaces
{
    public interface IPersonService
    {
        //Sutvarkyti pagal koki modeli kaip teisingai turi buti pakeistas PersonDto
        Task<ServiceResponse<PersonDto>> CreatePersonAsync(int userId, PersonDto dto);
        Task<ServiceResponse<PersonDto>> UpdatePersonAsync(int userId, int personId, PersonDto dto);
        Task<ServiceResponse<PersonDto>> GetPersonByIdAsync(int userId, int personId);
        Task<ServiceResponse<PersonDto>> UpdatePersonNameAsync(int userId, int personId, string firstName, string lastName);
    }
}
