using AutoMapper;
using newZealandWalks.API.Models.Domain;
using newZealandWalks.API.Models.DTO;

namespace newZealandWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<Region, RegionAddRequestDTO>().ReverseMap();
            CreateMap<Region, UpdateRegionDTO>().ReverseMap();

            CreateMap<Walk, WalkAddDTO>().ReverseMap();
            CreateMap<Walk, WalkDTO>().ReverseMap();
        }
    }
}
