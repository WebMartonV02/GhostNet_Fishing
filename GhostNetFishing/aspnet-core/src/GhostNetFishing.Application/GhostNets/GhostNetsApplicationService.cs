using GhostNetFishing.Repositories.Common;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace GhostNetFishing.GhostNets
{
    public class GhostNetsApplicationService : GhostNetFishingAppService, ITransientDependency
    {
        public readonly DefaultRepository<GhostNet> _ghostNetDefaultRepository;

        public GhostNetsApplicationService(DefaultRepository<GhostNet> ghostNetDefaultRepository)
        {
            _ghostNetDefaultRepository = ghostNetDefaultRepository;
        }

        public async Task<PagedResultDto<GhostNetResultDto>> GetListAsync(PagedAndSortedResultRequestDto requestDto)
        {
            var ghostNets = (await _ghostNetDefaultRepository.GetListWithNestedsAsync()).ToList();

            var totalCount = ghostNets.Count();

            var ghostNetsForTable = ghostNets.Skip(requestDto.SkipCount).Take(requestDto.MaxResultCount).ToList();

            var ghostNetResultDtos = ObjectMapper.Map<List<GhostNet>, List<GhostNetResultDto>>(ghostNetsForTable);

            return new PagedResultDto<GhostNetResultDto>(totalCount, ghostNetResultDtos);
        }

        public async Task<GhostNetResultDto> GetAsync(int id)
        {
            var ghostNet = await _ghostNetDefaultRepository.GetWithNestedsAsync(id);

            var ghostNetResultDto = ObjectMapper.Map<GhostNet, GhostNetResultDto>(ghostNet);

            return ghostNetResultDto;
        }

        public async Task CreateAsync(GhostNetRequestDto ghostNet)
        {
            var entityToBeCreated = new GhostNet(ghostNet.EstimatedSize, ghostNet.Standort, ghostNet.GhostNetStatusId);

            await _ghostNetDefaultRepository.InsertAsync(entityToBeCreated);   
        }

        public async Task UpdateAsync(GhostNetRequestDto ghostNet)
        {
            var storedEntity = await _ghostNetDefaultRepository.FirstOrDefaultAsync(x => x.Id == ghostNet.Id);

            if (storedEntity == null) throw new UserFriendlyException($"Ghostnet with the following unique identifier is not existing:{ghostNet.Id}");

            var updatedEntity = storedEntity.Update(ghostNet.EstimatedSize, ghostNet.Standort, ghostNet.GhostNetStatusId);

            await _ghostNetDefaultRepository.UpdateAsync(updatedEntity);
        }

        public async Task DeleteAsync(int id)
        {
            var entityToBeDeleted = await _ghostNetDefaultRepository.GetAsync(x => x.Id == id);

            await _ghostNetDefaultRepository.DeleteAsync(entityToBeDeleted);
        }
    }
}
