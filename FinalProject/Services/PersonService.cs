using FinalProject.BusinessLogic.Services.Interfaces;
using FinalProject.Database.Entities;
using FinalProject.Database.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalProject.BusinessLogic.Dtos;

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

            if (dto.ProfilePhoto != null)
            {
                person.ProfilePhoto = PhotoService.ResizeImage(dto.ProfilePhoto);
            }

            await _personRepository.AddAsync(person);
            var resultDto = _mapper.Map<PersonDto>(person);
            return new ServiceResponse<PersonDto> { Success = true, Data = resultDto };
        }

        public async Task<ServiceResponse<PersonDto>> GetPersonByIdAsync(int userId, int personId)
        {
            var person = await _personRepository.GetByIdAsync(personId);
            if (person == null || person.UserId != userId)
                return new ServiceResponse<PersonDto> { Success = false, Message = "Person not found or unauthorized." };

            var resultDto = _mapper.Map<PersonDto>(person);
            return new ServiceResponse<PersonDto> { Success = true, Data = resultDto };
        }

        public async Task<ServiceResponse<PersonDto>> UpdatePersonNameAsync(int userId, int personId, string firstName, string lastName)
        {
            var person = await _personRepository.GetByIdAsync(personId);
            if (person == null || person.UserId != userId)
                return new ServiceResponse<PersonDto> { Success = false, Message = "Person not found or unauthorized." };

            person.FirstName = firstName;
            person.LastName = lastName;

            await _personRepository.UpdateAsync(person);
            var resultDto = _mapper.Map<PersonDto>(person);
            return new ServiceResponse<PersonDto> { Success = true, Data = resultDto };
        }

        Task<ServiceResponse<PersonDto>> IPersonService.UpdatePersonAsync(int userId, int personId, PersonDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
