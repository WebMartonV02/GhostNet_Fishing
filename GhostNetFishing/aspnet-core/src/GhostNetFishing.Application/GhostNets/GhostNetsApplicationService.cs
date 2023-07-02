using GhostNetFishing.Common.Interfaces;
using GhostNetFishing.GhostNetStatuses;
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
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Users;
using EntityClass = GhostNetFishing.GhostNets.GhostNet;
using EntityRequestClassDto = GhostNetFishing.GhostNets.GhostNetRequestDto;
using EntityResultClassDto = GhostNetFishing.GhostNets.GhostNetResultDto;

namespace GhostNetFishing.GhostNets
{
    public class GhostNetsApplicationService : GhostNetFishingAppService, ITransientDependency
    {
        private readonly IDefaultRepository<EntityClass> _defaultRepository;
        private readonly IRepository<IdentityUser> _userRepository;
        private readonly ICurrentUser _currentUser;
        private readonly IPermissionManager _permissionManager;

        public GhostNetsApplicationService(
            IDefaultRepository<EntityClass> defaultRepository,
            IRepository<IdentityUser> userRepository,
            ICurrentUser currentUser,
            IPermissionManager permissionManager)
        {
            _defaultRepository = defaultRepository;
            _userRepository = userRepository;
            _currentUser = currentUser;
            _permissionManager = permissionManager;
        }

        public async Task<PagedResultDto<EntityResultClassDto>> GetListAsync(PagedAndSortedResultRequestDto requestDto)
        {
            var entities = (await _defaultRepository.GetListWithNestedsAsync()).ToList();

            var totalCount = entities.Count();

            var entitiesForTable = entities.Skip(requestDto.SkipCount).Take(requestDto.MaxResultCount).ToList();

            var entityResultDtos = ObjectMapper.Map<List<EntityClass>, List<EntityResultClassDto>>(entitiesForTable);

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
            var entityToBeCreated = new EntityClass(requestDto.EstimatedSize, requestDto.Location, requestDto.GhostNetStatusId);

            await _defaultRepository.InsertAsync(entityToBeCreated);   
        }

        public async Task UpdateAsync(EntityRequestClassDto requestDto)
        {
            if (requestDto.GhostNetStatusId == ((int)GhostNetStatusesEnum.Verschollen) && _currentUser.PhoneNumber is null)
            {
                throw new UserFriendlyException("GhostNet cant be marked as Verschollen as anonymous!");
            }

            var recoveringUserPermissions = (await _permissionManager.GetAllForUserAsync((Guid)_currentUser.Id))
                .Where(x => x.Name == GhostNetFishingPermissions.GhostNet.Recovering);

            if (recoveringUserPermissions is null && requestDto.GhostNetStatusId == ((int)GhostNetStatusesEnum.Geborgen))
            {
                throw new UserFriendlyException("GhostNet cant be marked as Geborgen without the required permission!");
            }

            var storedEntity = await _defaultRepository.FirstOrDefaultAsync(x => x.Id == requestDto.Id);

            if (storedEntity == null) throw new UserFriendlyException($"Ghostnet with the following unique identifier is not existing: {requestDto.Id}");

            var updatedEntity = storedEntity.Update(requestDto.Location, requestDto.EstimatedSize, requestDto.GhostNetStatusId);

            await _defaultRepository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var entityToBeDeleted = await _defaultRepository.GetAsync(x => x.Id == id);

            await _defaultRepository.DeleteAsync(entityToBeDeleted);
        }
    }
}
