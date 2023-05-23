using AutoMapper;
using AutoMapper.QueryableExtensions;
using GhostNetFishing.EntityFrameworkCore;
using GhostNetFishing.Repositories.Common.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GhostNetFishing.Repositories.Common
{
    public class DefaultRepository<TEntity> : EfCoreRepository<GhostNetFishingDbContext,TEntity>, IDefaultRepository<TEntity> where TEntity : class, IEntity<Guid>
    {
        private readonly IMapper _mapper;

        public DefaultRepository(
            IMapper mapper,
            IDbContextProvider<GhostNetFishingDbContext> dbContextProvider) : base(dbContextProvider)
        {
                _mapper = mapper;
        }

        public async Task<IQueryable<TEntity>> GetListWithNestedsAsync()
        {
            var dbSet = await GetDbContextAsync();

            var result = dbSet.Set<TEntity>()
                .ProjectTo<TEntity>(_mapper.ConfigurationProvider);

            return result;
        }
    }
}
