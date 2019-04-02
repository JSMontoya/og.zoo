﻿namespace OG.Zoo.Domain.Interfaces.Generics
{
    using Entities.Generics;
    using Infraestructure.Utils.Generics;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Base Service
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IBaseService<TEntity, TId> where TEntity : Base
    {
        /// <summary>
        /// Creates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task Create(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task Update(TEntity entity);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        Task Delete(TId id);

        /// <summary>
        /// Gets by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TEntity> Get(TId id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAll();

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="pageIndex">The page.</param>
        /// <param name="pageSize">The items per page.</param>
        /// <param name="sortBy">The sort by.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        Task<Paginated<TEntity>> GetAll(int pageIndex, int pageSize, string sortBy, string direction);
    }
}
