using Announcements.Domain.Entities.Shared;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Announcements.Application.Interfaces.Repositories
{

    /// <summary>
    /// Интерфейс родительского репозитория
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity, in TId>
        where TEntity : BaseEntity<TId>
    {

        /// <summary>
        /// Получить все записи из БД
        /// </summary>
        IQueryable<TEntity> FindAll();


        /// <summary>
        /// Получить запись по id из БД
        /// </summary>
        Task<TEntity> FindById(TId id, CancellationToken cancellationToken);


        /// <summary>
        /// Сохранить изменения в БД
        /// </summary>
        Task Save(CancellationToken cancellationToken);


        /// <summary>
        /// Добавить запись в БД
        /// </summary>
        Task Add(TEntity entity, CancellationToken cancellationToken);


        /// <summary>
        /// Обновить запись в БД
        /// </summary>
        Task Update(TEntity entity, CancellationToken cancellationToken);


        /// <summary>
        /// Найти запись по предикату
        /// </summary>
        Task<TEntity> FindWhere(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);

    }
}
