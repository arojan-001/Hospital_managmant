using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_management.Models;

namespace Hospital_management.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapping from Business Layer DTO to Presentation Layer ViewModel
            CreateMap<PersonDTO, PersonViewModel>();
            CreateMap<DoctorDTO, DoctorViewModel>();
            CreateMap<DepartmentDTO, DepartmentViewModel>();
            CreateMap<AppointmentDTO, AppointmentViewModel>();
            CreateMap<OtherStaffDTO, OtherStaffViewModel>();
            CreateMap<PatientDTO, PatientViewModel>();
            CreateMap<PatientVisitDTO, PatientVisitViewModel>();
            CreateMap<DoctorPatientDTO, DoctorPatientViewModel>();
            CreateMap<LoginDTO, LoginViewModel>();

            // Mapping from ViewModel back to DTO
            CreateMap<PersonViewModel, PersonDTO>();
            CreateMap<DoctorViewModel, DoctorDTO>();
            CreateMap<DepartmentViewModel, DepartmentDTO>();
            CreateMap<AppointmentViewModel, AppointmentDTO>();
            CreateMap<OtherStaffViewModel, OtherStaffDTO>();
            CreateMap<PatientViewModel, PatientDTO>();
            CreateMap<PatientVisitViewModel, PatientVisitDTO>();
            CreateMap<DoctorPatientViewModel, DoctorPatientDTO>();
            CreateMap<LoginViewModel, LoginDTO>();
        }
    }
}
