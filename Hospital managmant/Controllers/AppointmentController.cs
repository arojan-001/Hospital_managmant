using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_management.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var appointmentDTOs = await _appointmentService.GetAllAppointmentsAsync();
            var appointmentViewModels = _mapper.Map<IEnumerable<AppointmentViewModel>>(appointmentDTOs);
            return View(appointmentViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var appointmentDto = _mapper.Map<AppointmentDTO>(viewModel);
            await _appointmentService.AddAppointmentAsync(appointmentDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var appointmentDto = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointmentDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<AppointmentViewModel>(appointmentDto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var appointmentDto = _mapper.Map<AppointmentDTO>(viewModel);
            await _appointmentService.UpdateAppointmentAsync(appointmentDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var appointmentDto = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointmentDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<AppointmentViewModel>(appointmentDto);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
