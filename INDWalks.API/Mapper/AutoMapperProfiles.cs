using AutoMapper;
using INDWalks.API.Models.Domain;
using INDWalks.API.Models.DTOs;

namespace INDWalks.API.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RequestRegionDto, Region>().ReverseMap();
            CreateMap<ResponseRegionDto, Region>().ReverseMap();
        }
    }
}
