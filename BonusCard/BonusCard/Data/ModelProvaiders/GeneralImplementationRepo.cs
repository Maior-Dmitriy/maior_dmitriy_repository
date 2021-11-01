using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BonusCard.Data
{
    public class GeneralImplementationRepo<T> : IRepositoriy<T> where T : class
    {
        protected readonly BonusSystemDbContext context;
        public GeneralImplementationRepo(BonusSystemDbContext model)
        {
            context = model;
        }

        /// <summary>
        /// Add entity to context
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }

        /// <summary>
        /// Delete entity on context
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Find entity by Guid ID
        /// </summary>
        /// <param name="id">Guin ID</param>
        /// <returns>Entity</returns>
        public T Get(Guid? id)
        {
            return context.Set<T>().Find(id);
        }

        /// <summary>
        /// Get entity list 
        /// </summary>
        /// <returns>Entity list</returns>
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Save context changes
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
