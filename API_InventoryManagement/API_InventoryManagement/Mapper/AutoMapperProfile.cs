
using API_InventoryManagement.DTO;
using API_InventoryManagement.Models;
using AutoMapper;

namespace MiniFapAPI.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerRequestDTO>().ReverseMap();
            //CreateMap<Course, CourseDTO>().ReverseMap();
            //CreateMap<Schedule, ScheduleDTO>().ReverseMap();
            //CreateMap<Subject, SubjectDTO>().ReverseMap();
        }
    }
}
