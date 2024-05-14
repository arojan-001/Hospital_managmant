using Hospital_BLL.DTO;

namespace Hospital_BLL.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetAllPersonsAsync();
        Task<PersonDTO> GetPersonByIdAsync(int id);
        Task AddPersonAsync(PersonDTO person);
        Task UpdatePersonAsync(PersonDTO person);
        Task DeletePersonAsync(int id);
    }
}
