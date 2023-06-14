using AutoMapper;
using GhostNetFishing.GhostNets;

namespace GhostNetFishing;

public class GhostNetFishingApplicationAutoMapperProfile : Profile
{
    public GhostNetFishingApplicationAutoMapperProfile()
    {
        CreateGhostNetMaps();
    }

    public void CreateGhostNetMaps()
    {
        CreateMap<GhostNet, GhostNetResultDto>();
    }
}
