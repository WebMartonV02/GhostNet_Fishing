using GhostNetFishing.Repositories.Common.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace GhostNetFishing.GhostNets
{
    public class GhostNetAppService : ApplicationService
    {
        private readonly IDefaultRepository<GhostNet> _defaultRepository;
        public GhostNetAppService(IDefaultRepository<GhostNet> defaultRepository)
        {
            _defaultRepository = defaultRepository;
        }

        public async Task<List<GhostNet>> GetAllAsync()
        {
            var result = (await _defaultRepository.GetListWithNestedsAsync()).ToList();

            //use objectmapper and a dto

            return result;
        }
    }
}
