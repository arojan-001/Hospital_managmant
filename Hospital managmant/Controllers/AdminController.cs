using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospital_management.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public AdminController(IDepartmentService departmentService, IDoctorService doctorService, IPersonService personService, IMapper mapper)
        {
            _departmentService = departmentService;
            _doctorService = doctorService;
            _personService = personService;
            _mapper = mapper;
        }
        // Unified Admin Dashboard
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            var doctors = await _doctorService.GetAllDoctorsAsync();

            var model = new AdminViewModel
            {
                Departments = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments),
                Doctors = _mapper.Map<IEnumerable<DoctorViewModel>>(doctors)
            };

            return View(model);
        }
        // Department Management

        public async Task<IActionResult> Departments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            var model = _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
            return View(model);
        }

        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDepartment(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var departmentDto = _mapper.Map<DepartmentDTO>(model);
                await _departmentService.AddDepartmentAsync(departmentDto);
                return RedirectToAction(nameof(Departments));
            }
            return View(model);
        }

        public async Task<IActionResult> EditDepartment(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<DepartmentViewModel>(department);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDepartment(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var departmentDto = _mapper.Map<DepartmentDTO>(model);
                await _departmentService.UpdateDepartmentAsync(departmentDto);
                return RedirectToAction(nameof(Departments));
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<DepartmentViewModel>(department);
            return View(model);
        }

        [HttpPost, ActionName("DeleteDepartment")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDepartmentConfirmed(int id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return RedirectToAction(nameof(Departments));
        }

        public async Task<IActionResult> DepartmentDetails(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<DepartmentViewModel>(department);
            return View(model);
        }

        // Doctor Management
        public async Task<IActionResult> Doctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            var model = _mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateDoctor()
        {
            ViewBag.Departments = _mapper.Map<IEnumerable<DepartmentViewModel>>(await _departmentService.GetAllDepartmentsAsync());
            ViewBag.Persons = _mapper.Map<IEnumerable<PersonViewModel>>(await _personService.GetAllPersonsAsync());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDoctor(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doctorDto = _mapper.Map<DoctorDTO>(model);
                await _doctorService.AddDoctorAsync(doctorDto);
                return RedirectToAction(nameof(Doctors));
            }
            ViewBag.Departments = _mapper.Map<IEnumerable<DepartmentViewModel>>(await _departmentService.GetAllDepartmentsAsync());
            ViewBag.Persons = _mapper.Map<IEnumerable<PersonViewModel>>(await _personService.GetAllPersonsAsync());
            return View(model);
        }

        public async Task<IActionResult> EditDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<DoctorViewModel>(doctor);
            ViewBag.Departments = _mapper.Map<IEnumerable<DepartmentViewModel>>(await _departmentService.GetAllDepartmentsAsync());
            ViewBag.Persons = _mapper.Map<IEnumerable<PersonViewModel>>(await _personService.GetAllPersonsAsync());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDoctor(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doctorDto = _mapper.Map<DoctorDTO>(model);
                await _doctorService.UpdateDoctorAsync(doctorDto);
                return RedirectToAction(nameof(Doctors));
            }
            ViewBag.Departments = _mapper.Map<IEnumerable<DepartmentViewModel>>(await _departmentService.GetAllDepartmentsAsync());
            ViewBag.Persons = _mapper.Map<IEnumerable<PersonViewModel>>(await _personService.GetAllPersonsAsync());
            return View(model);
        }

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<DoctorViewModel>(doctor);
            return View(model);
        }

        [HttpPost, ActionName("DeleteDoctor")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDoctorConfirmed(int id)
        {
            await _doctorService.DeleteDoctorAsync(id);
            return RedirectToAction(nameof(Doctors));
        }

        public async Task<IActionResult> DoctorDetails(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<DoctorViewModel>(doctor);
            return View(model);
        }
    }
}
