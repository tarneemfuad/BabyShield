using AutoMapper;
using babyShield.DTOs;
using babyShield.Models;

namespace babyShield
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Admin, AdminDtos>();
            CreateMap<AdminDtos, Admin>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<Manager, ManagerDtos>();
            CreateMap<Reception, ReceptionDtos>();
            CreateMap<Clinic, ClinicDtos>();
            CreateMap<ClinicDtos, Clinic>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<Doctor, DoctorDtos>();
            CreateMap<DoctorDtos, Doctor>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
