using System.Linq;
using System.Threading.Tasks;

namespace GhostNetFishing.Repositories.Common.Interfaces
{
    public interface IDefaultRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetListWithNestedsAsync();
    }
}
