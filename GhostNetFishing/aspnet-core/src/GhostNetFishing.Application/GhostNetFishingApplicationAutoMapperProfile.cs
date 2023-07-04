using AutoMapper;
using GhostNetFishing.GhostNetAndPersons;
using GhostNetFishing.GhostNets;
using GhostNetFishing.GhostNetsAndPersons;
using GhostNetFishing.GhostNetStatuses;
using GhostNetFishing.User;
using Volo.Abp.Identity;

namespace GhostNetFishing;

public class GhostNetFishingApplicationAutoMapperProfile : Profile
{
    public GhostNetFishingApplicationAutoMapperProfile()
    {
        CreateGhostNetMaps();
        CreateGhostNetsAndPersonsMaps();
        CreateUserMaps();
    }

    private void CreateGhostNetMaps()
    {
        CreateMap<GhostNet, GhostNetResultDto>();
        CreateMap<GhostNet, GhostNet>();
        CreateMap<GhostNetRequestDto, GhostNet>();

        CreateMap<GhostNetStatus, GhostNetStatusResultDto>();
    }

    private void CreateUserMaps()
    {
        CreateMap<IdentityUser, UserResultDto>();
    }

    private void CreateGhostNetsAndPersonsMaps()
    {
        CreateMap<GhostNetAndPerson, GhostNetAndPersonResultDto>();
        CreateMap<GhostNetAndPerson, GhostNetAndPerson>();
        CreateMap<GhostNetAndPersonRequestDto, GhostNetAndPerson>();
        CreateMap<GhostNetAndPersonResultDomainModel, GhostNetAndPersonResultDto>();
        CreateMap<GhostNetAndPerson, GhostNetAndPersonResultDomainModel>()
            .ForMember(dst => dst.GhostNet, opt => opt.MapFrom(src => src.GhostNet));
    }
}
