using AutoMapper;
using SGED.Objects.DTO.Entities;
using SGED.Objects.Models.Entities;

namespace SGED.Objects.DTO.Mappings
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