using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_DAL.Entities;
using Hospital_DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace Hospital_BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task RegisterAsync(RegistrationDTO registrationDto)
        {
            if (registrationDto.Password != registrationDto.ConfirmPassword)
                throw new ArgumentException("Passwords do not match");

            var login = new Login
            {
                Email = registrationDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registrationDto.Password), // Hash the password
                Type = registrationDto.Role == "Admin" ? 0 : (registrationDto.Role == "Doctor" ? 1 : 2) // Example role mapping
            };

            await _userRepository.AddAsync(login);
        }

        public async Task RegisterWithDetailsAsync(LoginDTO loginDto, PersonDTO personDto, string role)
        {
            var login = new Login
            {
                Email = loginDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(loginDto.Password), // Hash the password
                Type = role == "Admin" ? 0 : (role == "Doctor" ? 1 : 2) // Example role mapping
            };

            await _userRepository.AddAsync(login);

            var person = new Person
            {
                ID = login.LoginID,
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
                PatrName = personDto.PatrName,
                Phone = personDto.Phone,
                Address = personDto.Address,
                City = personDto.City,
                Country = personDto.Country,
                BirthDate = personDto.BirthDate,
                Gender = personDto.Gender,
                BloodGroup = personDto.BloodGroup
            };

            await _userRepository.AddPersonAsync(person);

            if (role == "Doctor")
            {
                var doctor = new Doctor
                {
                    PersonID = person.ID,
                    DeptNo = 1, // Set the department number appropriately
                    Charges_Per_Visit = 100, // Set other fields
                };
                await _userRepository.AddDoctorAsync(doctor);
            }
            else if (role == "Patient")
            {
                var patient = new Patient
                {
                    PersonID = person.ID,
                    TreatmentStatus = 0 // Set other fields
                };
                await _userRepository.AddPatientAsync(patient);
            }
        }

        public async Task<int> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password)) // Verify hashed password
            {
                throw new UnauthorizedAccessException("Invalid credentials");
            }

            // Generate and return a JWT token or session ID
            return user.Type;
        }
        public async Task SeedDefaultAdminAsync()
        {
            var adminEmail = "admin@hospital.com"; // Default admin email
            var adminPassword = "Admin@123"; // Default admin password

            var existingAdmin = await _userRepository.GetByEmailAsync(adminEmail);
            if (existingAdmin == null)
            {
                var admin = new Login
                {
                    Email = adminEmail,
                    Password = BCrypt.Net.BCrypt.HashPassword(adminPassword), // Hash the password
                    Type = 0 // Admin role
                };

                await _userRepository.AddAsync(admin);

                var person = new Person
                {
                    ID = admin.LoginID,
                    FirstName = "Default",
                    LastName = "Admin",
                    Phone = "0000000000",
                    Address = "Default Address",
                    City = "Default City",
                    Country = "Default Country",
                    BirthDate = DateTime.Now,
                    Gender = 'M',
                    BloodGroup = "O+"
                };

                await _userRepository.AddPersonAsync(person);
            }
        }
    }
}
