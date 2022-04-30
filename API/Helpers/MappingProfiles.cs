using API.Dtos;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
        }
    }
}