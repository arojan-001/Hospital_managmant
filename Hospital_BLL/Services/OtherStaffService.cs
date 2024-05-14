using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_DAL.Interfaces;
using Hospital_DAL.Entities;

namespace Hospital_BLL.Services
{
    public class OtherStaffService : IOtherStaffService
    {
        private readonly IOtherStaffRepository _otherStaffRepository;
        private readonly IMapper _mapper;

        public OtherStaffService(IOtherStaffRepository otherStaffRepository, IMapper mapper)
        {
            _otherStaffRepository = otherStaffRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OtherStaffDTO>> GetAllOtherStaffAsync()
        {
            var otherStaffs = await _otherStaffRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OtherStaffDTO>>(otherStaffs);
        }

        public async Task<OtherStaffDTO> GetOtherStaffByIdAsync(int id)
        {
            var otherStaff = await _otherStaffRepository.GetByIdAsync(id);
            return _mapper.Map<OtherStaffDTO>(otherStaff);
        }

        public async Task AddOtherStaffAsync(OtherStaffDTO otherStaffDto)
        {
            var otherStaff = _mapper.Map<OtherStaff>(otherStaffDto);
            await _otherStaffRepository.AddAsync(otherStaff);
        }

        public async Task UpdateOtherStaffAsync(OtherStaffDTO otherStaffDto)
        {
            var otherStaff = await _otherStaffRepository.GetByIdAsync(otherStaffDto.StaffID);
            if (otherStaff != null)
            {
                _mapper.Map(otherStaffDto, otherStaff);
                await _otherStaffRepository.UpdateAsync(otherStaff);
            }
        }

        public async Task DeleteOtherStaffAsync(int id)
        {
            await _otherStaffRepository.DeleteAsync(id);
        }
    }
}
