using GhostNetFishing.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using EntityClass = GhostNetFishing.Persons.Person;
using EntityRequestClassDto = GhostNetFishing.Persons.PersonRequestDto;
using EntityResultClassDto = GhostNetFishing.Persons.PersonResultDto;

namespace GhostNetFishing.Persons
{
    public class PersonAppService : GhostNetFishingAppService, ITransientDependency
    {
        public readonly IDefaultRepository<EntityClass> _defaultRepository;

        public PersonAppService(IDefaultRepository<EntityClass> defaultRepository)
        {
            _defaultRepository = defaultRepository;
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
            var entityToBeCreated = new EntityClass(requestDto.Name, requestDto.TelefonNummer, requestDto.PersonTypeId);

            await _defaultRepository.InsertAsync(entityToBeCreated);
        }

        public async Task UpdateAsync(EntityRequestClassDto requestDto)
        {
            var storedEntity = await _defaultRepository.FirstOrDefaultAsync(x => x.Id == requestDto.Id);

            if (storedEntity == null) throw new UserFriendlyException($"Ghostnet with the following unique identifier is not existing: {requestDto.Id}");

            var updatedEntity = storedEntity.Update(requestDto.Name, requestDto.TelefonNummer, requestDto.PersonTypeId);

            await _defaultRepository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var entityToBeDeleted = await _defaultRepository.GetAsync(x => x.Id == id);

            await _defaultRepository.DeleteAsync(entityToBeDeleted);
        }

    }
}
