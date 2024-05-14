using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_management.Controllers
{
    public class OtherStaffController : Controller
    {
        private readonly IOtherStaffService _otherStaffService;
        private readonly IMapper _mapper;

        public OtherStaffController(IOtherStaffService otherStaffService, IMapper mapper)
        {
            _otherStaffService = otherStaffService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var otherStaffDTOs = await _otherStaffService.GetAllOtherStaffAsync();
            var otherStaffViewModels = _mapper.Map<IEnumerable<OtherStaffViewModel>>(otherStaffDTOs);
            return View(otherStaffViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OtherStaffViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var otherStaffDto = _mapper.Map<OtherStaffDTO>(viewModel);
            await _otherStaffService.AddOtherStaffAsync(otherStaffDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var otherStaffDto = await _otherStaffService.GetOtherStaffByIdAsync(id);
            if (otherStaffDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<OtherStaffViewModel>(otherStaffDto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OtherStaffViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var otherStaffDto = _mapper.Map<OtherStaffDTO>(viewModel);
            await _otherStaffService.UpdateOtherStaffAsync(otherStaffDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var otherStaffDto = await _otherStaffService.GetOtherStaffByIdAsync(id);
            if (otherStaffDto == null)
            {
                return NotFound();
            }
            var viewModel = _mapper.Map<OtherStaffViewModel>(otherStaffDto);
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _otherStaffService.DeleteOtherStaffAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
