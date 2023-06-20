using GhostNetFishing.GhostNets;
using GhostNetFishing.GhostNetStatuses;
using GhostNetFishing.Persons;
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
        private readonly IRepository<GhostNet> _ghostNetRepository;
        private readonly IRepository<Person> _personRepository;

        private PersonType meldendePersonTypeId;
        private PersonType bergendePersonTypeId;

        private GhostNetStatus gemeldeteGhostNetStatus;
        private GhostNetStatus bergungBevorstehendeGhostNetStatus;
        private GhostNetStatus beborgenGhostNetStatus;
        private GhostNetStatus verschollenGhostNetStatus;

        public GhostNetFishingDataSeederContributor(
            IRepository<PersonType> personTypeRepository,
            IRepository<GhostNetStatus> ghostNetStatusRepository,
            IRepository<GhostNet> ghostNetRepository,
            IRepository<Person> personRepository)
        {
            _personTypeRepository = personTypeRepository;
            _ghostNetStatusRepository = ghostNetStatusRepository;
            _ghostNetRepository = ghostNetRepository;
            _personRepository = personRepository;
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
#if DEBUG
            await AddPersons();
            await AddGhostNets();
#endif
        }

        private async Task AddPersonTypes()
        {
            if (await _personTypeRepository.GetCountAsync() > 0) return;

            meldendePersonTypeId = await _personTypeRepository.InsertAsync(new PersonType("Meldende"), autoSave: true);
            bergendePersonTypeId = await _personTypeRepository.InsertAsync(new PersonType("Bergende"), autoSave: true);
        }

        private async Task AddGhostNetStatuses()
        {
            if (await _ghostNetStatusRepository.GetCountAsync() > 0) return;

            gemeldeteGhostNetStatus = await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("Gemeldet"), autoSave: true);
            bergungBevorstehendeGhostNetStatus = await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("BergungBevorstehend"), autoSave: true);
            beborgenGhostNetStatus = await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("Geborgen"), autoSave: true);
            verschollenGhostNetStatus = await _ghostNetStatusRepository.InsertAsync(new GhostNetStatus("Verschollen"), autoSave: true);
        }

        private async Task AddPersons()
        {
            if (await _personRepository.GetCountAsync() > 0) return;

            await _personRepository.InsertAsync(new Person("FirstName1 Lastname1", "+4915140000001", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName2 Lastname2", "+4915140000002", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName3 Lastname3", "+4915140000003", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName4 Lastname4", "+4915140000004", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName5 Lastname5", "+4915140000005", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName6 Lastname6", "+4915140000006", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName7 Lastname7", "+4915140000007", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName8 Lastname8", "+4915140000008", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName9 Lastname9", "+4915140000009", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName10 Lastname10", "+4915140000010", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName11 Lastname11", "+4915140000011", meldendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName12 Lastname12", "+4915140000012", meldendePersonTypeId.Id));


            await _personRepository.InsertAsync(new Person("FirstName13 Lastname13", "+4915140000013", bergendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName14 Lastname14", "+4915140000014", bergendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName15 Lastname15", "+4915140000015", bergendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName16 Lastname16", "+4915140000016", bergendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName17 Lastname17", "+4915140000017", bergendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName18 Lastname18", "+4915140000018", bergendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName19 Lastname19", "+4915140000019", bergendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName20 Lastname20", "+4915140000020", bergendePersonTypeId.Id));
            await _personRepository.InsertAsync(new Person("FirstName21 Lastname21", "+4915140000021", bergendePersonTypeId.Id));
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
