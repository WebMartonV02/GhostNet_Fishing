using GhostNetFishing.GhostNets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GhostNetFishing.GhostNetAndPersons.Interfaces
{
    public interface IGhostNetAssignmentDomainService
    {
        Task<List<GhostNet>> GetAllUnassginedGhostNet();
        Task<List<GhostNetAndPersonResultDomainModel>> GenerateAllNonExistingAssignmentRecords(List<GhostNet> unassigndeGhostNets);
    }
}
