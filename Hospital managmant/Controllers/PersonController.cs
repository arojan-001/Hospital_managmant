using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_management.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        // Index action to list all persons
        public async Task<IActionResult> Index()
        {
            var personDTOs = await _personService.GetAllPersonsAsync();
            var personViewModels = _mapper.Map<IEnumerable<PersonViewModel>>(personDTOs);
            return View(personViewModels);
        }

        // Create action to show the create form
        public IActionResult Create()
        {
            return View();
        }

        // Create action to handle form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var personDto = _mapper.Map<PersonDTO>(viewModel);
            await _personService.AddPersonAsync(personDto);
            return RedirectToAction(nameof(Index));
        }

        // Edit action to show the edit form
        public async Task<IActionResult> Edit(int id)
        {
            var personDto = await _personService.GetPersonByIdAsync(id);
            if (personDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<PersonViewModel>(personDto);
            return View(viewModel);
        }

        // Edit action to handle form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var personDto = _mapper.Map<PersonDTO>(viewModel);
            await _personService.UpdatePersonAsync(personDto);
            return RedirectToAction(nameof(Index));
        }

        // Details action to show details of a person
        public async Task<IActionResult> Details(int id)
        {
            var personDto = await _personService.GetPersonByIdAsync(id);
            if (personDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<PersonViewModel>(personDto);
            return View(viewModel);
        }

        // Delete action to show the delete confirmation
        public async Task<IActionResult> Delete(int id)
        {
            var personDto = await _personService.GetPersonByIdAsync(id);
            if (personDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<PersonViewModel>(personDto);
            return View(viewModel);
        }

        // Delete action to handle form submission
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _personService.DeletePersonAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
