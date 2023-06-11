using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tourismo.Core.Model.TravelManagement;
using Tourismo.Core.Persistence;
using Tourismo.Core.Repository.Interface;
using Tourismo.Core.Utility;

namespace Tourismo.Core.Repository.Implementation
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : BaseObservableEntity
    {
        protected DatabaseContext _context;
        protected DbSet<T> _entities;

        public CRUDRepository(DatabaseContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public virtual IEnumerable<T> ReadAll()
        {
            return _entities.IncludeAll().ToList();
        }

        public virtual T Read(Guid id)
        {
            return _entities.FirstOrDefault(e => e.Id == id);
        }

        public virtual T Create(T entity)
        {
            _entities.Add(entity);

            if (entity is Arrangement)
            {
                foreach (var entry in _context.ChangeTracker.Entries())
                {
                    if (entry.Entity != entity && entry.State != EntityState.Unchanged)
                    {
                        entry.State = EntityState.Unchanged;
                    }
                }
            }

            else if (entity is Travel)
            {
                
            }

            _context.SaveChanges();

            return entity;
        }


        public virtual T Update(T entity)
        {
            var entityToUpdate = Read(entity.Id);
            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }

            return entityToUpdate;
        }

        public virtual T Delete(Guid id)
        {
            var entityToDelete = Read(id);
            if (entityToDelete != null)
            {
                _context.Remove(entityToDelete);
                _context.SaveChanges();
            }

            return entityToDelete;
        }
    }
}
