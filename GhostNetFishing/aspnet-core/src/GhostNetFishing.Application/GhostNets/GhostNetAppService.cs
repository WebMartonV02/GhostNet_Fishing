using GhostNetFishing.Repositories.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace GhostNetFishing.GhostNets
{
    public class GhostNetAppService : ApplicationService
    {
        private readonly IDefaultRepository<GhostNetStatus> _defaultRepository;
        private readonly IRepository<GhostNetStatus, int> _ghostNetRepository;
        public GhostNetAppService(
            IDefaultRepository<GhostNetStatus> defaultRepository,
            IRepository<GhostNetStatus, int> ghostNetRepository)
        {
            _defaultRepository = defaultRepository;
            _ghostNetRepository = ghostNetRepository;
        }

        public async Task<List<GhostNetDto>> GetAllAsync()
        {
            var storedEntities = (await _defaultRepository.GetListWithNestedsAsync()).ToList();

            var result = ObjectMapper.Map<List<GhostNetStatus>, List<GhostNetDto>>(storedEntities);

            return result;
        }

        public async Task<GhostNetDto> GetAsync(int ghostNetId)
        {
            var storedEntity = await _ghostNetRepository.GetAsync(ghostNetId);

            var result = ObjectMapper.Map<GhostNetStatus, GhostNetDto>(storedEntity);

            return result;
        }

        public async Task CreateAsync(GhostNetRequestDto ghostNetRequest)
        {
            var entityToBeCreated = ObjectMapper.Map<GhostNetRequestDto, GhostNetStatus>(ghostNetRequest);

            await _ghostNetRepository.InsertAsync(entityToBeCreated);
        }
    }
}
