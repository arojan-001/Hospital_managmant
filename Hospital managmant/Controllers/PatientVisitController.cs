using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_management.Controllers
{
    public class PatientVisitController : Controller
    {
        private readonly IPatientVisitService _patientVisitService;
        private readonly IMapper _mapper;

        public PatientVisitController(IPatientVisitService patientVisitService, IMapper mapper)
        {
            _patientVisitService = patientVisitService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var patientVisitDTOs = await _patientVisitService.GetAllPatientVisitsAsync();
            var patientVisitViewModels = _mapper.Map<IEnumerable<PatientVisitViewModel>>(patientVisitDTOs);
            return View(patientVisitViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientVisitViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var patientVisitDto = _mapper.Map<PatientVisitDTO>(viewModel);
            await _patientVisitService.AddPatientVisitAsync(patientVisitDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patientVisitDto = await _patientVisitService.GetPatientVisitByIdAsync(id);
            if (patientVisitDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<PatientVisitViewModel>(patientVisitDto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PatientVisitViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var patientVisitDto = _mapper.Map<PatientVisitDTO>(viewModel);
            await _patientVisitService.UpdatePatientVisitAsync(patientVisitDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var patientVisitDto = await _patientVisitService.GetPatientVisitByIdAsync(id);
            if (patientVisitDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<PatientVisitViewModel>(patientVisitDto);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _patientVisitService.DeletePatientVisitAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
