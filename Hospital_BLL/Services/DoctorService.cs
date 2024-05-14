using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_DAL.Interfaces;
using Hospital_DAL.Entities;

namespace Hospital_BLL.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorDTO>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
        }

        public async Task<DoctorDTO> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            return _mapper.Map<DoctorDTO>(doctor);
        }

        public async Task AddDoctorAsync(DoctorDTO doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);
            await _doctorRepository.AddAsync(doctor);
        }

        public async Task UpdateDoctorAsync(DoctorDTO doctorDto)
        {
            var doctor = await _doctorRepository.GetByIdAsync(doctorDto.DoctorID);
            if (doctor != null)
            {
                _mapper.Map(doctorDto, doctor);
                await _doctorRepository.UpdateAsync(doctor);
            }
        }

        public async Task DeleteDoctorAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }
    }
}
