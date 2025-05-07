using AutoMapper;
using HRBackend.Application.DTO;
using HRBackend.Domain.Entities;

namespace HRBackend.Application.Mapping
{
    public class WorkingGroupProfile : Profile
    {
        public WorkingGroupProfile()
        {
            //CreateMap<WorkingGroup, WorkingGroupDTO>();

            CreateMap<WorkingGroup, WorkingGroupDTO>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
