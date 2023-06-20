using GhostNetFishing.Common.Interfaces;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GhostNetFishing.GhostNetStatuses
{
    public class GhostNetStatusAppService: GhostNetFishingAppService, ITransientDependency
    {
        private readonly IDefaultRepository<GhostNetStatus> _ghostNetStatusDefaultRepository;

        public GhostNetStatusAppService(IDefaultRepository<GhostNetStatus> ghostNetStatusDefaultRepository)
        {
            _ghostNetStatusDefaultRepository = ghostNetStatusDefaultRepository;
        }

        public async Task<GhostNetStatusResultDto> Get(int ghostNetStatusId)
        {
            var result = await _ghostNetStatusDefaultRepository.GetAsync(x => x.Id == ghostNetStatusId);

            var mappedResultDto = ObjectMapper.Map<GhostNetStatus, GhostNetStatusResultDto>(result);

            return mappedResultDto;
        }
    }
}
