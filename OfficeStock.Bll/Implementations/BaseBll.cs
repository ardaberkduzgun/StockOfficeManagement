
 using OfficeStock.Bll.Interfaces;
using OfficeStock.Dal.Implamentations;
using OfficeStock.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OfficeStock.Bll.Implamentations
{
    public class BaseBll<Component> : IBaseBll<Component> where Component : BaseEntity
    {
        #region Entity

        public BaseDal<Component> Dal { get; set; }

        public BaseBll(BaseDal<Component> dal)
        {
            Dal = dal;
        }

        public virtual void Insert(Component entity)
        {
            try
            {
                Dal.Insert(entity);
            }
            catch
            {
                throw;
            }
        }

        public virtual void Delete(Component entity)
        {
            try
            {
                Dal.Delete(entity);
            }
            catch
            {
                throw;
            }
        }

        public virtual void Update(Component entity)
        {
            try
            {
                Dal.Update(entity);
            }
            catch
            {
                throw;
            }
        }
        public virtual void Updatee(Component entity)
        {
            try
            {
                Dal.Updatee(entity);
            }
            catch
            {
                throw;
            }
        }
        public virtual Component Get(System.Linq.Expressions.Expression<Func<Component, bool>> predicate)
        {
            Component entity = null;
            try
            {
                entity = Dal.Get(predicate);
            }
            catch
            {
                throw;
            }

            return entity;
        }

        public virtual IEnumerable<Component> Gets(System.Linq.Expressions.Expression<Func<Component, bool>> predicate)
        {
            List<Component> entities = null;

            try
            {
                entities = Dal.Gets(predicate).ToList();
            }
            catch
            {
                throw;
            }

            return entities;
        }

        public virtual IEnumerable<Component> GetAll()
        {
            List<Component> entities = null;

            try
            {
                entities = Dal.GetAll().ToList();
            }
            catch
            {
                throw;
            }

            return entities;
        }

        #endregion
    }
}
 
