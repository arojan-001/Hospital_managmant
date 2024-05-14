using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_management.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var patientDTOs = await _patientService.GetAllPatientsAsync();
            var patientViewModels = _mapper.Map<IEnumerable<PatientViewModel>>(patientDTOs);
            return View(patientViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var patientDto = _mapper.Map<PatientDTO>(viewModel);
            await _patientService.AddPatientAsync(patientDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patientDto = await _patientService.GetPatientByIdAsync(id);
            if (patientDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<PatientViewModel>(patientDto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var patientDto = _mapper.Map<PatientDTO>(viewModel);
            await _patientService.UpdatePatientAsync(patientDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var patientDto = await _patientService.GetPatientByIdAsync(id);
            if (patientDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<PatientViewModel>(patientDto);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
