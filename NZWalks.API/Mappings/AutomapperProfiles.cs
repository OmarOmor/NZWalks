using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Mappings
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles() 
        {
            //Region Mapping
            CreateMap<Region,RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDTO, Region>().ReverseMap();


            //Walks Mapping
            CreateMap<AddWalksRequestDTO, Walk>().ReverseMap();
            CreateMap<Walk,WalksDTO>().ReverseMap();
            CreateMap<UpdateWalkDTO, Walk>().ReverseMap();

            //Difficulty Mapping
            CreateMap<Difficulty,DifficultyDTO>().ReverseMap(); 
        }
    }
}
