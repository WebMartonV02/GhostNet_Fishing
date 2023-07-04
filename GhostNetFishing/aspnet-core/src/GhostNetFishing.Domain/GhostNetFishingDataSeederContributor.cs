using GhostNetFishing.GhostNets;
using GhostNetFishing.GhostNetStatuses;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace GhostNetFishing
{
    public class GhostNetFishingDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<GhostNetStatus> _ghostNetStatusRepository;
        private readonly IRepository<GhostNet> _ghostNetRepository;

        private GhostNetStatus gemeldeteGhostNetStatus;
        private GhostNetStatus bergungBevorstehendeGhostNetStatus;
        private GhostNetStatus beborgenGhostNetStatus;
        private GhostNetStatus verschollenGhostNetStatus;

        public GhostNetFishingDataSeederContributor(
            IRepository<GhostNetStatus> ghostNetStatusRepository,
            IRepository<GhostNet> ghostNetRepository)
        {
            _ghostNetStatusRepository = ghostNetStatusRepository;
            _ghostNetRepository = ghostNetRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await CreateNecessaryRootData(context);
            await CreateDataForTesting(context);
        }

        private async Task CreateNecessaryRootData(DataSeedContext context)
        {
            await AddGhostNetStatuses();
        }

        private async Task CreateDataForTesting(DataSeedContext context)
        {
#if DEBUG
            await AddGhostNets();
#endif
        }

        private async Task AddGhostNetStatuses()
        {
            if (await _ghostNetStatusRepository.GetCountAsync() > 0) return;

            gemeldeteGhostNetStatus = await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("Gemeldet"), autoSave: true);
            bergungBevorstehendeGhostNetStatus = await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("BergungBevorstehend"), autoSave: true);
            beborgenGhostNetStatus = await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("Geborgen"), autoSave: true);
            verschollenGhostNetStatus = await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("Verschollen"), autoSave: true);
        }

        private async Task AddGhostNets()
        {
            if (await _ghostNetRepository.GetCountAsync() > 0) return;

            await _ghostNetRepository.InsertAsync(new GhostNet("41.40338, 2.17403", "100", gemeldeteGhostNetStatus.Id));
            await _ghostNetRepository.InsertAsync(new GhostNet("42.40338, 3.17403", "100", gemeldeteGhostNetStatus.Id));
            await _ghostNetRepository.InsertAsync(new GhostNet("43.40338, 4.17403", "100", gemeldeteGhostNetStatus.Id));
            await _ghostNetRepository.InsertAsync(new GhostNet("44.40338, 5.17403", "100", gemeldeteGhostNetStatus.Id)); 

            await _ghostNetRepository.InsertAsync(new GhostNet("14.40338, 2.17403", "100", bergungBevorstehendeGhostNetStatus.Id)); 
            await _ghostNetRepository.InsertAsync(new GhostNet("14.40338, 3.17403", "100", bergungBevorstehendeGhostNetStatus.Id)); 
            await _ghostNetRepository.InsertAsync(new GhostNet("14.40338, 4.17403", "100", bergungBevorstehendeGhostNetStatus.Id)); 
            await _ghostNetRepository.InsertAsync(new GhostNet("14.40338, 5.17403", "100", bergungBevorstehendeGhostNetStatus.Id)); 

            await _ghostNetRepository.InsertAsync(new GhostNet("24.40338, 2.17403", "100", beborgenGhostNetStatus.Id)); 
            await _ghostNetRepository.InsertAsync(new GhostNet("24.40338, 3.17403", "100", beborgenGhostNetStatus.Id)); 
            await _ghostNetRepository.InsertAsync(new GhostNet("24.40338, 4.17403", "100", beborgenGhostNetStatus.Id)); 
            await _ghostNetRepository.InsertAsync(new GhostNet("24.40338, 5.17403", "100", beborgenGhostNetStatus.Id)); 

            await _ghostNetRepository.InsertAsync(new GhostNet("34.40338, 2.17403", "100", verschollenGhostNetStatus.Id)); 
            await _ghostNetRepository.InsertAsync(new GhostNet("34.40338, 3.17403", "100", verschollenGhostNetStatus.Id)); 
            await _ghostNetRepository.InsertAsync(new GhostNet("34.40338, 4.17403", "100", verschollenGhostNetStatus.Id)); 
            await _ghostNetRepository.InsertAsync(new GhostNet("34.40338, 5.17403", "100", verschollenGhostNetStatus.Id)); 
        }
    }
}
