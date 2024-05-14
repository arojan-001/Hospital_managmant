using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_DAL.Interfaces;

namespace Hospital_BLL.Services
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

        public async Task<IEnumerable<PersonDTO>> GetAllPersonsAsync()
        {
            var persons = await _personRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonDTO>>(persons);
        }

        public async Task<PersonDTO> GetPersonByIdAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            return _mapper.Map<PersonDTO>(person);
        }

        public async Task AddPersonAsync(PersonDTO personDto)
        {
            var person = new Hospital_DAL.Entities.Person
            {
                // Map from DTO to Entity
            };
            await _personRepository.AddAsync(person);
        }

        public async Task UpdatePersonAsync(PersonDTO personDto)
        {
            var person = await _personRepository.GetByIdAsync(personDto.ID);
            if (person != null)
            {
                // Map updated fields from DTO to Entity
                await _personRepository.UpdateAsync(person);
            }
        }

        public async Task DeletePersonAsync(int id)
        {
            await _personRepository.DeleteAsync(id);
        }
    }
}
