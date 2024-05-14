//using AutoMapper;
//using Hospital_BLL.DTO;
//using Hospital_BLL.Interfaces;
//using Hospital_management.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace Hospital_management.Controllers
//{
//    public class DoctorPatientController : Controller
//    {
//        private readonly IDoctorPatientService _doctorPatientService;
//        private readonly IMapper _mapper;

//        public DoctorPatientController(IDoctorPatientService doctorPatientService, IMapper mapper)
//        {
//            _doctorPatientService = doctorPatientService;
//            _mapper = mapper;
//        }

//        public async Task<IActionResult> Index()
//        {
//            var doctorPatientDTOs = await _doctorPatientService.GetAllDoctorPatientsAsync();
//            var doctorPatientViewModels = _mapper.Map<IEnumerable<DoctorPatientViewModel>>(doctorPatientDTOs);
//            return View(doctorPatientViewModels);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(DoctorPatientViewModel viewModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(viewModel);
//            }

//            var doctorPatientDto = _mapper.Map<DoctorPatientDTO>(viewModel);
//            await _doctorPatientService.AddDoctorPatientAsync(doctorPatientDto);
//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Edit(int doctorId, int patientId)
//        {
//            var doctorPatientDto = await _doctorPatientService.GetDoctorPatientByIdAsync(doctorId, patientId);
//            if (doctorPatientDto == null)
//            {
//                return NotFound();
//            }
//            var viewModel = _mapper.Map<DoctorPatientViewModel>(doctorPatientDto);
//            return View(viewModel);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(DoctorPatientViewModel viewModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(viewModel);
//            }

//            var doctorPatientDto = _mapper.Map<DoctorPatientDTO>(viewModel);
//            await _doctorPatientService.UpdateDoctorPatientAsync(doctorPatientDto);
//            return RedirectToAction(nameof(Index));
//        }

//        public async Task<IActionResult> Delete(int doctorId, int patientId)
//        {
//            var doctorPatientDto = await _doctorPatientService.GetDoctorPatientByIdAsync(doctorId, patientId);
//            if (doctorPatientDto == null)
//            {
//                return NotFound();
//            }
//            var viewModel = _mapper.Map<DoctorPatientViewModel>(doctorPatientDto);
//            return View(viewModel);
//        }

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int doctorId, int patientId)
//        {
//            await _doctorPatientService.DeleteDoctorPatientAsync(doctorId, patientId);
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}
