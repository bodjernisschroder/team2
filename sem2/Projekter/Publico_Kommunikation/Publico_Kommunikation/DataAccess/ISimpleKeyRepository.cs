﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publico_Kommunikation.DataAccess
{
    /// <summary>
    /// A repository interface for managing entities with simple keys.
    /// Extends the functionality of the <see cref="IRepository{T}"/> interface.
    /// </summary>
    /// <typeparam name="T">The entity type managed by the repository.</typeparam>
    public interface ISimpleKeyRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves an entity of type <typeparamref name="T"/> by its primary key.
        /// </summary>
        /// <param name="key">The primary key of the entity to retrieve.</param>
        /// <returns>The entity of type <typeparamref name="T"/> that matches the specified <paramref name="key"/>.</returns>
        T GetByKey(int key);

        /// <summary>
        /// Deletes an entity of type <typeparamref name="T"/>, identified by its primary key.
        /// </summary>
        /// <param name="key">The primary key of the entity to delete.</param>
        void Delete(int key);
    }
}
