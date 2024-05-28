using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_management.Models;
using Hospital_managmant.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_management.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var doctorDTOs = await _doctorService.GetAllDoctorsAsync();
            var doctorViewModels = _mapper.Map<IEnumerable<DoctorViewModel>>(doctorDTOs);
            return View(doctorViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var doctorDto = _mapper.Map<DoctorDTO>(viewModel);
            await _doctorService.AddDoctorAsync(doctorDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doctorDto = await _doctorService.GetDoctorByIdAsync(id);
            if (doctorDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<DoctorViewModel>(doctorDto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var doctorDto = _mapper.Map<DoctorDTO>(viewModel);
            await _doctorService.UpdateDoctorAsync(doctorDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var doctorDto = await _doctorService.GetDoctorByIdAsync(id);
            if (doctorDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<DoctorViewModel>(doctorDto);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
