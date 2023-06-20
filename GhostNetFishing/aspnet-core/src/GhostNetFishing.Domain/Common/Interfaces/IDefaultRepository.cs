using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace GhostNetFishing.Common.Interfaces
{
    public interface IDefaultRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity<int>
    {
        Task<IQueryable<TEntity>> GetListWithNestedsAsync();
        Task<TEntity> GetWithNestedsAsync(int id);
    }
}
