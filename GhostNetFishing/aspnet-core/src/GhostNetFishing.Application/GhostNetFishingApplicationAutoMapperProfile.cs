using AutoMapper;
using GhostNetFishing.GhostNetAndPersons;
using GhostNetFishing.GhostNets;
using GhostNetFishing.GhostNetsAndPersons;
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
        CreateGhostNetsAndPersonsMaps();
    }

    private void CreateGhostNetMaps()
    {
        CreateMap<GhostNet, GhostNetResultDto>();
        CreateMap<GhostNet, GhostNet>();
        CreateMap<GhostNetRequestDto, GhostNet>();

        CreateMap<GhostNetStatus, GhostNetStatusResultDto>();
    }

    private void CreatePersonMaps()
    {
        CreateMap<Person, PersonResultDto>();
        CreateMap<Person, Person>();
        CreateMap<PersonRequestDto, Person>();

        CreateMap<PersonType, PersonTypeResultDto>();
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
