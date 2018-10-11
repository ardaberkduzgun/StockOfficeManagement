using System;
using System.Collections.Generic;
using System.Linq;
using OfficeStock.Dal.Interfaces;
using System.Data.Entity;
using OfficeStock.Entity;

namespace OfficeStock.Dal.Implamentations
{
    public class BaseDal<Component> : IBaseDal<Component> where Component : BaseEntity
    {
        public DbContext Context { get; set; }
        private DbSet<Component> DbSet { get; set; }

        public BaseDal(DbContext dbContext)
        {
            this.Context = dbContext;
            DbSet = Context.Set<Component>();
        }
        public void Insert(Component entity)
        {
            try
            {
                DbSet.Add(entity);
                Context.SaveChanges();
            }
            catch
            {
                throw;
            }
            finally
            {
                Dispose();
            }
        }
        public void Delete(Component entity)
        {
            try
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    DbSet.Attach(entity);
                Context.Entry(entity).CurrentValues.SetValues(entity);

                Context.Entry(entity).State = EntityState.Deleted;
                Context.SaveChanges();
            }
            catch
            {
                throw;
            }
            finally
            {
                Dispose();
            }
        }
        public void Update(Component entity)
        {
            try
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    DbSet.Attach(entity);

                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
            }
            catch
            {
                throw;
            }
            finally
            {
                Dispose();
            }
        }
        public void Updatee(Component entity)
        {
            try
            {
                if (Context.Entry(entity).State == EntityState.Detached)
                    DbSet.Attach(entity);

                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
            }
            catch
            {
                throw;
            }
            finally
            {
                Dispose();
            }
        }
        public Component Get(System.Linq.Expressions.Expression<Func<Component, bool>> predicate)
        {
            Component entity = null;
            try
            {
                entity = DbSet.Where(predicate).FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                Dispose();
            }

            return entity;
        }
        public IEnumerable<Component> Gets(System.Linq.Expressions.Expression<Func<Component, bool>> predicate)
        {
            List<Component> entities = null;
            try
            {
                entities = DbSet.Where(predicate).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                Dispose();
            }
            return entities;
        }
        public IEnumerable<Component> GetAll()
        {
            List<Component> entities = null;

            try
            {
                entities = DbSet.ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                Dispose();
            }
            return entities;
        }
        public virtual void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
