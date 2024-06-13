using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database.Entities;
using FinalProject.Database.Repositories.Interfaces;
using AutoMapper;
using FinalProject.BusinessLogic.Dtos;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.BusinessLogic.Services
{


    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PersonDto>> CreatePersonAsync(int userId, PersonDto dto)
        {
            var person = _mapper.Map<Person>(dto);
            person.UserId = userId;

            await _personRepository.AddAsync(person);
            var resultDto = _mapper.Map<PersonDto>(person);
            return new ServiceResponse<PersonDto> { Success = true, Data = resultDto };
        }

        public async Task<ServiceResponse<PersonDto>> GetPersonByIdAsync(int userId, int personId)
        {
            var person = await _personRepository.GetByIdAsync(personId);
            if (person.UserId != userId)
                return new ServiceResponse<PersonDto> { Success = false, Message = "Person not found or unauthorized." };

            var resultDto = _mapper.Map<PersonDto>(person);
            return new ServiceResponse<PersonDto> { Success = true, Data = resultDto };
        }

        public async Task<ServiceResponse<PersonDto>> UpdatePersonNameAsync(int userId, int personId, string firstName, string lastName)
        {
            var person = await _personRepository.GetByIdAsync(personId);
            if (person.UserId != userId)
                return new ServiceResponse<PersonDto> { Success = false, Message = "Person not found or unauthorized." };

            person.FirstName = firstName;
            person.LastName = lastName;

            await _personRepository.UpdateAsync(person);
            var resultDto = _mapper.Map<PersonDto>(person);
            return new ServiceResponse<PersonDto> { Success = true, Data = resultDto };
        }

        public async Task<ServiceResponse<PersonDto>> UpdatePersonAsync(int userId, int personId, PersonDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<PersonDto>> DeletePersonAsync(int userId, int personId)
        {
            var person = await _personRepository.GetByIdAsync(personId);
            if (person.UserId != userId)
                return new ServiceResponse<PersonDto> { Success = false, Message = "Person not found or unauthorized." };

            await _personRepository.DeletePersonAsync(person);
            var resultDto = _mapper.Map<PersonDto>(person);
            return new ServiceResponse<PersonDto> { Success = true, Data = resultDto };
        }
    }
}
