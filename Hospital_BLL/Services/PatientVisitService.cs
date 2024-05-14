using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_BLL.Interfaces;
using Hospital_DAL.Interfaces;
using Hospital_DAL.Entities;

namespace Hospital_BLL.Services
{
    public class PatientVisitService : IPatientVisitService
    {
        private readonly IPatientVisitRepository _patientVisitRepository;
        private readonly IMapper _mapper;

        public PatientVisitService(IPatientVisitRepository patientVisitRepository, IMapper mapper)
        {
            _patientVisitRepository = patientVisitRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatientVisitDTO>> GetAllPatientVisitsAsync()
        {
            var patientVisits = await _patientVisitRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientVisitDTO>>(patientVisits);
        }

        public async Task<PatientVisitDTO> GetPatientVisitByIdAsync(int id)
        {
            var patientVisit = await _patientVisitRepository.GetByIdAsync(id);
            return _mapper.Map<PatientVisitDTO>(patientVisit);
        }

        public async Task AddPatientVisitAsync(PatientVisitDTO patientVisitDto)
        {
            var patientVisit = _mapper.Map<PatientVisit>(patientVisitDto);
            await _patientVisitRepository.AddAsync(patientVisit);
        }

        public async Task UpdatePatientVisitAsync(PatientVisitDTO patientVisitDto)
        {
            var patientVisit = await _patientVisitRepository.GetByIdAsync(patientVisitDto.ID);
            if (patientVisit != null)
            {
                _mapper.Map(patientVisitDto, patientVisit);
                await _patientVisitRepository.UpdateAsync(patientVisit);
            }
        }

        public async Task DeletePatientVisitAsync(int id)
        {
            await _patientVisitRepository.DeleteAsync(id);
        }
    }
}
