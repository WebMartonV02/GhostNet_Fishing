using GhostNetFishing.GhostNetAndPersons.Interfaces;
using GhostNetFishing.GhostNets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace GhostNetFishing.GhostNetAndPersons
{
    public class GhostNetAssignmentDomainService : IGhostNetAssignmentDomainService, ITransientDependency
    {
        private readonly IRepository<GhostNet> _ghostNetRepository;
        private readonly IRepository<GhostNetAndPerson> _ghostNetAndPersonRepository;
        private readonly IObjectMapper _objectMapper;

        public GhostNetAssignmentDomainService(
            IRepository<GhostNet> ghostNetRepository,
            IRepository<GhostNetAndPerson> ghostNetAndPersonRepository,
            IObjectMapper objectMapper)
        {
            _ghostNetRepository = ghostNetRepository;
            _ghostNetAndPersonRepository = ghostNetAndPersonRepository;
            _objectMapper = objectMapper;
        }

        public async Task<List<GhostNet>> GetAllUnassginedGhostNet()
        {
            var allGhostNetsWithAssignment = await _ghostNetAndPersonRepository.GetListAsync();
            var allGhostNets = await _ghostNetRepository.GetListAsync();

            var result = allGhostNets.Where(x => !allGhostNetsWithAssignment.Select(x => x.GhostNetId).Contains(x.Id)).ToList();

            return result;
        }

        public async Task<List<GhostNetAndPersonResultDomainModel>> GenerateAllNonExistingAssignmentRecords(List<GhostNet> unassigndeGhostNets)
        {
            var result = new List<GhostNetAndPersonResultDomainModel>();

            foreach (var ghostNet in unassigndeGhostNets)
            {
                var ghostNetPersonWithoutAssignedPerson = new GhostNetAndPerson(ghostNet.Id);

                var mappedDto = _objectMapper.Map<GhostNetAndPerson, GhostNetAndPersonResultDomainModel>(ghostNetPersonWithoutAssignedPerson);

                result.Add(mappedDto);
            }
            
            return result;
        }
    }
}
