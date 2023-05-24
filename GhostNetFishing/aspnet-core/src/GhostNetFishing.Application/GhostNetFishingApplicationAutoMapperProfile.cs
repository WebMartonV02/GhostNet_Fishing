using AutoMapper;
using GhostNetFishing.GhostNets;

namespace GhostNetFishing;

public class GhostNetFishingApplicationAutoMapperProfile : Profile
{
    public GhostNetFishingApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateGhostNetMappings();
    }

    public void CreateGhostNetMappings()
    {
        CreateMap<GhostNet, GhostNetDto>()
            .ForMember(dst => dst.Standort, opt => opt.MapFrom(src => src.Standort))
            .ForMember(dst => dst.EstimatedSize, opt => opt.MapFrom(src => src.EstimatedSize))
            .ForMember(dst => dst.GhostNetStatusType, opt => opt.MapFrom(src => src.GhostNetStatus.Type));

        CreateMap<GhostNetRequestDto, GhostNetStatus>();
    }
}
