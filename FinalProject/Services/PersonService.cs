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


        public async Task<ServiceResponse<PersonDto>> UpdatePersonAsync(int userId, int personId, PersonDto dto)
        {
            var person = await _personRepository.GetByIdAsync(personId);
            if (person.UserId != userId)
                return new ServiceResponse<PersonDto> { Success = false, Message = "Person not found or unauthorized." };

            var result = _mapper.Map<Person>(dto);
            result.UserId = userId;
            await _personRepository.UpdateAsync(result);
            return new ServiceResponse<PersonDto> { Success = true, Data = dto };
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
