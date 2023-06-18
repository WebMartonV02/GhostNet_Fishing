using GhostNetFishing.GhostNetAndPersons;
using GhostNetFishing.GhostNetAndPersons.Interfaces;
using GhostNetFishing.GhostNetsAndPersons;
using GhostNetFishing.Repositories.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

using EntityClass = GhostNetFishing.GhostNetAndPersons.GhostNetAndPerson;
using EntityRequestClassDto = GhostNetFishing.GhostNetsAndPersons.GhostNetAndPersonRequestDto;
using EntityResultClassDto = GhostNetFishing.GhostNetsAndPersons.GhostNetAndPersonResultDto;

namespace GhostNetFishing.GhostNets
{
    public class GhostNetsAndPersonsApplicationService : GhostNetFishingAppService, ITransientDependency
    {
        private readonly IDefaultRepository<EntityClass> _defaultRepository;
        private readonly IDefaultRepository<GhostNet> _ghostNetDefaultRepository;
        private readonly IGhostNetAssignmentDomainService _ghostNetAssignmentDomainService;

        public GhostNetsAndPersonsApplicationService(
            IDefaultRepository<EntityClass> defaultRepository,
            IDefaultRepository<GhostNet> ghostNetDefaultRepository,
            IGhostNetAssignmentDomainService ghostNetAssignmentDomainService)
        {
            _defaultRepository = defaultRepository;
            _ghostNetDefaultRepository = ghostNetDefaultRepository;
            _ghostNetAssignmentDomainService = ghostNetAssignmentDomainService;
        }

        public async Task<PagedResultDto<EntityResultClassDto>> GetListWithUnassignedGhostNetsAsync(PagedAndSortedResultRequestDto requestDto)
        {
            var allUnassignedGhostNets = await _ghostNetAssignmentDomainService.GetAllUnassginedGhostNet();

            var generatedGhostNetAndPersonDomainModel = await _ghostNetAssignmentDomainService.GenerateAllNonExistingAssignmentRecords(allUnassignedGhostNets);

            var mappedDtoToResultDto = ObjectMapper.Map<List<GhostNetAndPersonResultDomainModel>, List<EntityResultClassDto>>(generatedGhostNetAndPersonDomainModel);

            var entities = (await _defaultRepository.GetListWithNestedsAsync()).ToList();

            var totalCount = entities.Count();

            var entitiesForTable = entities.Skip(requestDto.SkipCount).Take(requestDto.MaxResultCount).ToList();

            var entityResultDtos = ObjectMapper.Map<List<EntityClass>, List<EntityResultClassDto>>(entitiesForTable);

            entityResultDtos.AddRange(mappedDtoToResultDto);

            return new PagedResultDto<EntityResultClassDto>(totalCount, entityResultDtos);
        }

        public async Task<EntityResultClassDto> GetAsync(int id)
        {
            var entity = await _defaultRepository.GetWithNestedsAsync(id);

            var entityResultDto = ObjectMapper.Map<EntityClass, EntityResultClassDto>(entity);

            return entityResultDto;
        }

        public async Task CreateAsync(EntityRequestClassDto requestDto)
        {
            var entityToBeCreated = new EntityClass(requestDto.GhostNetId, requestDto.PersonId);

            await _defaultRepository.InsertAsync(entityToBeCreated);   
        }

        public async Task UpdateAsync(EntityRequestClassDto requestDto)
        {
            var storedEntity = await _defaultRepository.FirstOrDefaultAsync(x => x.Id == requestDto.Id);

            if (storedEntity == null) throw new UserFriendlyException($"Ghostnet with the following unique identifier is not existing: {requestDto.Id}");

            var updatedEntity = storedEntity.Update(requestDto.GhostNetId, requestDto.PersonId);

            await _defaultRepository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var entityToBeDeleted = await _defaultRepository.GetAsync(x => x.Id == id);

            await _defaultRepository.DeleteAsync(entityToBeDeleted);
        }
    }
}
