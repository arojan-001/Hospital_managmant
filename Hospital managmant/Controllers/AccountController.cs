using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_management.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Hospital_management.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CombinedViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var loginDto = new LoginDTO
            {
                Email = viewModel.Registration.Email,
                Password = viewModel.Registration.Password,
                Type = viewModel.Registration.Role.Equals("Doctor") ? 1 : 2,
            };

            var personDto = new PersonDTO
            {
                FirstName = viewModel.AdditionalInfo.FirstName,
                LastName = viewModel.AdditionalInfo.LastName,
                PatrName = viewModel.AdditionalInfo.MiddleName,
                Email = viewModel.Registration.Email,
                Phone = viewModel.AdditionalInfo.PhoneNumber,
                Address = viewModel.AdditionalInfo.Address,
                City = viewModel.AdditionalInfo.City,
                Country = viewModel.AdditionalInfo.Country,
                BirthDate = viewModel.AdditionalInfo.BirthDate,
                Gender = viewModel.AdditionalInfo.Gender,
                BloodGroup = viewModel.AdditionalInfo.BloodGroup
            };

            await _userService.RegisterWithDetailsAsync(loginDto, personDto, viewModel.Registration.Role);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var loginDto = _mapper.Map<LoginDTO>(viewModel);
            var result = await _userService.LoginAsync(loginDto);
            if (result == 0)
            {

                return RedirectToAction("Index", "Admin");
            }

            if (result == 1 || result == 2)
            {

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View(viewModel);
        }
    }
}
