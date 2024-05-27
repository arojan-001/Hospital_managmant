using Hospital_BLL.DTO;
using System.Threading.Tasks;

namespace Hospital_BLL.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegistrationDTO registrationDto);
        Task RegisterWithDetailsAsync(LoginDTO loginDto, PersonDTO personDto, string role);
        Task<string> LoginAsync(LoginDTO loginDto);

        Task SeedDefaultAdminAsync();
    }
}
