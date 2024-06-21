using AutoMapper;
using DesignPattern.Objects.DTO.Entities;
using DesignPattern.Objects.Models.Entities;

namespace DesignPattern.Objects.DTO.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskDTO, TaskModel>();
            CreateMap<TaskModel, TaskDTO>().ReverseMap();
        }
    }
}