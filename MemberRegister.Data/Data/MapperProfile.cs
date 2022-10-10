using AutoMapper;
using MemberRegister.Core.Dto;
using MemberRegister.Core.Entities;

namespace MemberRegister.Data.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {
            //CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<Member, MemberDto>()
                .ForMember(dest => dest.LastUpdatedDate, from => from.MapFrom(d => d.LastUpdatedDate.ToShortDateString()))
                .ForMember(dest => dest.CreationDate, from => from.MapFrom(d => d.CreationDate.ToShortDateString()));

            CreateMap<MemberDto, Member>();
        }
    }
}
