using GhostNetFishing.GhostNetStatuses;
using GhostNetFishing.PersonTypes;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace GhostNetFishing
{
    public class GhostNetFishingDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<PersonType> _personTypeRepository;
        private readonly IRepository<GhostNetStatus> _ghostNetStatusRepository;

        public GhostNetFishingDataSeederContributor(
            IRepository<PersonType> personTypeRepository, 
            IRepository<GhostNetStatus> ghostNetStatusRepository)
        {
            _personTypeRepository = personTypeRepository;
            _ghostNetStatusRepository = ghostNetStatusRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateNecessaryRootData(context);
            await CreateDataForTesting(context);
        }

        private async Task CreateNecessaryRootData(DataSeedContext context)
        {
            await AddPersonTypes();
            await AddGhostNetStatuses();
        }

        private async Task CreateDataForTesting(DataSeedContext context)
        {
            
        }

        private async Task AddPersonTypes()
        {
            if (await _personTypeRepository.GetCountAsync() > 0) return;

            await _personTypeRepository.InsertAsync(new PersonType("Meldende"));
            await _personTypeRepository.InsertAsync(new PersonType("Bergende"));
        }

        private async Task AddGhostNetStatuses()
        {
            if (await _ghostNetStatusRepository.GetCountAsync() > 0) return;

            await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("Gemeldet"));
            await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("Bergung bevorstehend"));
            await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("Geborgen"));
            await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("Verschollen"));
        }
    }
}
