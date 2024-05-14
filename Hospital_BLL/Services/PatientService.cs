using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_DAL.Interfaces;
using Hospital_DAL.Entities;

namespace Hospital_BLL.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientDTO>> GetAllPatientsAsync()
        {
            var patients = await _patientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientDTO>>(patients);
        }

        public async Task<PatientDTO> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            return _mapper.Map<PatientDTO>(patient);
        }

        public async Task AddPatientAsync(PatientDTO patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            await _patientRepository.AddAsync(patient);
        }

        public async Task UpdatePatientAsync(PatientDTO patientDto)
        {
            var patient = await _patientRepository.GetByIdAsync(patientDto.PatientID);
            if (patient != null)
            {
                _mapper.Map(patientDto, patient);
                await _patientRepository.UpdateAsync(patient);
            }
        }

        public async Task DeletePatientAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }
    }
}
