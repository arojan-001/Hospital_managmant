using AutoMapper;
using Hospital_BLL.DTO;
using Hospital_DAL.Entities;

namespace Hospital_BLL.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Doctor mappings
            CreateMap<Doctor, DoctorDTO>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));
            CreateMap<DoctorDTO, Doctor>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

            // Department mappings
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentDTO, Department>();

            // Person mappings
            CreateMap<Person, PersonDTO>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login));
            CreateMap<PersonDTO, Person>()
                .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login));

            // Login mappings
            CreateMap<Login, LoginDTO>();
            CreateMap<LoginDTO, Login>();

            // Appointment mappings
            CreateMap<Appointment, AppointmentDTO>()
                .ForMember(dest => dest.PatientVisit, opt => opt.MapFrom(src => src.PatientVisit));
            CreateMap<AppointmentDTO, Appointment>()
                .ForMember(dest => dest.PatientVisit, opt => opt.MapFrom(src => src.PatientVisit));

            // DoctorPatient mappings
            CreateMap<DoctorPatient, DoctorPatientDTO>()
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient));
            CreateMap<DoctorPatientDTO, DoctorPatient>()
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient));

            // OtherStaff mappings
            CreateMap<OtherStaff, OtherStaffDTO>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));
            CreateMap<OtherStaffDTO, OtherStaff>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person));

            // Patient mappings
            CreateMap<Patient, PatientDTO>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.DoctorPatients, opt => opt.MapFrom(src => src.DoctorPatients));
            CreateMap<PatientDTO, Patient>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))
                .ForMember(dest => dest.DoctorPatients, opt => opt.MapFrom(src => src.DoctorPatients));

            // PatientVisit mappings
            CreateMap<PatientVisit, PatientVisitDTO>()
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient));
            CreateMap<PatientVisitDTO, PatientVisit>()
                .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor))
                .ForMember(dest => dest.Patient, opt => opt.MapFrom(src => src.Patient));
        }
    }
}
