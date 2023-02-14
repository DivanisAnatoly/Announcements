using Announcements.Application.Interfaces.Repositories;
using Announcements.Domain.Entities.Shared;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Infrastructure.DataAccess.Repositories
{
    /// <summary>Родительский репозиторий</summary>
    /// <inheritdoc cref="IRepository{TEntity}"/>
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : BaseEntity<TId>
    {
        protected readonly AnnouncementDBContext _DBContext;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Repository(AnnouncementDBContext DBContext)
        {
            _DBContext = DBContext;
        }


        /// <inheritdoc/>
        public async Task Add(TEntity entity, CancellationToken cancellationToken)
        {
            await _DBContext.AddAsync(entity, cancellationToken);
            await Save(cancellationToken);
        }


        /// <inheritdoc/>
        public async Task<TEntity> FindById(TId id, CancellationToken cancellationToken)
        {
            return await _DBContext.FindAsync<TEntity>(new object[] { id }, cancellationToken);
        }


        /// <inheritdoc/>
        public IQueryable<TEntity> FindAll()
        {
            return _DBContext.Set<TEntity>();
        }


        /// <inheritdoc/>
        public async Task Save(CancellationToken cancellationToken)
        {
            await _DBContext.SaveChangesAsync(cancellationToken);
        }


        /// <inheritdoc/>
        public async Task Update(TEntity entity, CancellationToken cancellationToken)
        {
            _DBContext.Update(entity);
            await Save(cancellationToken);
        }


        /// <inheritdoc/>
        public Task<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
