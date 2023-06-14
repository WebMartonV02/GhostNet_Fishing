using GhostNetFishing.Repositories.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;

namespace GhostNetFishing.GhostNets
{
    public class GhostNetsApplicationService : GhostNetFishingAppService, ITransientDependency
    {
        public readonly IDefaultRepository<GhostNet> _ghostNetDefaultRepository;

        public GhostNetsApplicationService(IDefaultRepository<GhostNet> ghostNetDefaultRepository)
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
    }
}
