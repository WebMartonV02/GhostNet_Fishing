using AutoMapper;
using GhostNetFishing.GhostNets;
using GhostNetFishing.GhostNetStatuses;
using GhostNetFishing.Persons;
using GhostNetFishing.PersonTypes;

namespace GhostNetFishing;

public class GhostNetFishingApplicationAutoMapperProfile : Profile
{
    public GhostNetFishingApplicationAutoMapperProfile()
    {
        CreateGhostNetMaps();
        CreatePersonMaps();
    }

    public void CreateGhostNetMaps()
    {
        CreateMap<GhostNet, GhostNetResultDto>();
        CreateMap<GhostNet, GhostNet>();
        CreateMap<GhostNetRequestDto, GhostNet>();

        CreateMap<GhostNetStatus, GhostNetStatusResultDto>();
    }

    public void CreatePersonMaps()
    {
        CreateMap<Person, PersonResultDto>();
        CreateMap<Person, Person>();
        CreateMap<PersonRequestDto, Person>();

        CreateMap<PersonType, PersonTypeResultDto>();
    }
}
