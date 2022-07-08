
using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using Aplication.DTOs;
using Aplication.DTOs.Validations;
using Aplication.Services.Interfaces;
using AutoMapper;

namespace Aplication.Services
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

        public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
        {
            if (personDTO == null)
                return ResultService.Fail<PersonDTO>("objeto deve ser informado");

            var result = new PersonDTOvalidator().Validate(personDTO);

            if (!result.IsValid)
            return ResultService.RequestError<PersonDTO>("problemas nos dados inseridos", result);

            var person = _mapper.Map<Person>(personDTO);

            var data = await _personRepository.CreateAsync(person);
            return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));

        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if(person == null)
                return  ResultService.Fail<PersonDTO>("pessoa nao encontrada");

            await _personRepository.DeleteAsync(person);
            return ResultService.Ok($"pessoa de id:{id} deletada");

        }

        public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
        {
            var people = await _personRepository.GetPeopleAsync();
            return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
        }

        public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            if(person == null)
                return  ResultService.Fail<PersonDTO>("pessoa nao encontrada");
            return ResultService.Ok(_mapper.Map<PersonDTO>(person));
        }

        public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
        {
            if(personDTO == null)
                return ResultService.Fail("informe os dados para atualizar");

            var validation = new PersonDTOvalidator().Validate(personDTO);
            if(!validation.IsValid)
                return ResultService.RequestError("valide os campos", validation);
            
            var person = await _personRepository.GetByIdAsync(personDTO.Id);
            if(person == null)
                return ResultService.Fail("Pessoa nao encontrada");
            
            person = _mapper.Map<PersonDTO, Person>(personDTO, person);
            await _personRepository.EditAsync(person);
                return ResultService.Ok("pessoa editada com sucesso");
        }
    }
}