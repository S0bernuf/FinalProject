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

        public Task<ServiceResponse<PersonDto>> CreatePersonAsync(int userId, PersonDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<PersonDto>> GetPersonByIdAsync(int userId, int personId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<PersonDto>> UpdatePersonAsync(int userId, int personId, PersonDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
