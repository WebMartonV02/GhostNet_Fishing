using GhostNetFishing.Common.Interfaces;
using GhostNetFishing.GhostNetAndPersons;
using GhostNetFishing.GhostNetAndPersons.Interfaces;
using GhostNetFishing.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Users;
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
        private readonly ICurrentUser _currentUser;
        private readonly IPermissionManager _permissionManager;

        public GhostNetsAndPersonsApplicationService(
            IDefaultRepository<EntityClass> defaultRepository,
            IDefaultRepository<GhostNet> ghostNetDefaultRepository,
            IGhostNetAssignmentDomainService ghostNetAssignmentDomainService,
            ICurrentUser currentUser,
            IPermissionManager permissionManager)
        {
            _defaultRepository = defaultRepository;
            _ghostNetDefaultRepository = ghostNetDefaultRepository;
            _ghostNetAssignmentDomainService = ghostNetAssignmentDomainService;
            _currentUser = currentUser;
            _permissionManager = permissionManager;
        }

        public async Task<PagedResultDto<EntityResultClassDto>> GetListWithUnassignedGhostNetsAsync(PagedAndSortedResultRequestDto requestDto)
        {
            var allUnassignedGhostNets = await _ghostNetAssignmentDomainService.GetAllUnassginedGhostNet();

            var generatedGhostNetAndPersonDomainModel = await _ghostNetAssignmentDomainService.GenerateAllNonExistingAssignmentRecords(allUnassignedGhostNets);

            var entities = (await _defaultRepository.GetListWithNestedsAsync()).ToList();

            var entitiesForTable = entities.Skip(requestDto.SkipCount).Take(requestDto.MaxResultCount).ToList();

            var entityWithIncludedUsers = await _ghostNetAssignmentDomainService.IncludeIdentityUserEntityIntoGhostNetEntity(entitiesForTable);

            entityWithIncludedUsers.AddRange(generatedGhostNetAndPersonDomainModel);

            var entityResultDtos = ObjectMapper.Map<List<GhostNetAndPersonResultDomainModel>, List<EntityResultClassDto>>(entityWithIncludedUsers);

            var totalCount = entityResultDtos.Count();

            return new PagedResultDto<EntityResultClassDto>(totalCount, entityResultDtos);
        }

        public async Task<EntityResultClassDto> GetAsync(int id)
        {
            var entity = await _defaultRepository.GetWithNestedsAsync(id);

            var entityResultDto = ObjectMapper.Map<EntityClass, EntityResultClassDto>(entity);

            return entityResultDto;
        }

        public async Task AssignCurrentUserToTheSpecificGhostnNet(int ghostNetId)
        {
            var recoveringUserPermissions = (await _permissionManager.GetAllForUserAsync((Guid)_currentUser.Id))
                .Where(x => x.Name == GhostNetFishingPermissions.GhostNet.Recovering);

            if (recoveringUserPermissions is null)
            {
                throw new UserFriendlyException($"User cannot be assigned to the GhostNet with following Id: {ghostNetId}, lack of permission");
            }

            var entityToBeSaved = new EntityClass(ghostNetId, (Guid)_currentUser.Id);

            await _defaultRepository.InsertAsync(entityToBeSaved);
        }

        public async Task CreateAsync(EntityRequestClassDto requestDto)
        {
            var entityToBeCreated = new EntityClass(requestDto.GhostNetId, requestDto.UserId);

            await _defaultRepository.InsertAsync(entityToBeCreated);   
        }

        public async Task UpdateAsync(EntityRequestClassDto requestDto)
        {
            var storedEntity = await _defaultRepository.FirstOrDefaultAsync(x => x.Id == requestDto.Id);

            if (storedEntity == null) throw new UserFriendlyException($"Ghostnet with the following unique identifier is not existing: {requestDto.Id}");

            var updatedEntity = storedEntity.Update(requestDto.GhostNetId, requestDto.UserId);

            await _defaultRepository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var entityToBeDeleted = await _defaultRepository.GetAsync(x => x.Id == id);

            await _defaultRepository.DeleteAsync(entityToBeDeleted);
        }
    }
}
