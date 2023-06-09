﻿using GhostNetFishing.Common.Interfaces;
using GhostNetFishing.GhostNetAndPersons.Interfaces;
using GhostNetFishing.GhostNets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;

namespace GhostNetFishing.GhostNetAndPersons
{
    public class GhostNetAssignmentDomainService : IGhostNetAssignmentDomainService, ITransientDependency
    {
        private readonly IDefaultRepository<GhostNet> _ghostNetRepository;
        private readonly IRepository<GhostNetAndPerson> _ghostNetAndPersonRepository;
        private readonly IRepository<IdentityUser> _userRepository;
        private readonly IObjectMapper _objectMapper;

        public GhostNetAssignmentDomainService(
            IDefaultRepository<GhostNet> ghostNetRepository,
            IRepository<GhostNetAndPerson> ghostNetAndPersonRepository,
            IRepository<IdentityUser> userRepository,
            IObjectMapper objectMapper)
        {
            _ghostNetRepository = ghostNetRepository;
            _ghostNetAndPersonRepository = ghostNetAndPersonRepository;
            _userRepository = userRepository;
            _objectMapper = objectMapper;
        }

        public async Task<List<GhostNet>> GetAllUnassginedGhostNet()
        {
            var allGhostNetsWithAssignment = await _ghostNetAndPersonRepository.GetListAsync();
            var allGhostNets = await _ghostNetRepository.GetListWithNestedsAsync();

            var result = allGhostNets.Where(x => !allGhostNetsWithAssignment.Select(x => x.GhostNetId).Contains(x.Id)).ToList();

            return result;
        }

        public async Task<List<GhostNetAndPersonResultDomainModel>> GenerateAllNonExistingAssignmentRecords(List<GhostNet> unassigndeGhostNets)
        {
            var result = new List<GhostNetAndPersonResultDomainModel>();

            foreach (var ghostNet in unassigndeGhostNets)
            {
                var ghostNetPersonWithoutAssignedPerson = new GhostNetAndPerson(ghostNet.Id, ghostNet);

                var mappedDto = _objectMapper.Map<GhostNetAndPerson, GhostNetAndPersonResultDomainModel>(ghostNetPersonWithoutAssignedPerson);

                result.Add(mappedDto);
            }
            
            return result;
        }

        public async Task<List<GhostNetAndPersonResultDomainModel>> IncludeIdentityUserEntityIntoGhostNetEntity(List<GhostNetAndPerson> ghostNetAndPersons)
        {
            var result = new List<GhostNetAndPersonResultDomainModel>();

            foreach (var ghostNetAndPerson in ghostNetAndPersons)
            {
                var belongingUser = await _userRepository.GetAsync(x => x.Id == ghostNetAndPerson.UserId);

                var entityResultDto = _objectMapper.Map<GhostNetAndPerson, GhostNetAndPersonResultDomainModel>(ghostNetAndPerson);
                entityResultDto.User = belongingUser;

                result.Add(entityResultDto);
            }

            return result;
        }
    }
}
