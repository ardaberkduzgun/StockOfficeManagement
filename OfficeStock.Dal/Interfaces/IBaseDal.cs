using OfficeStock.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OfficeStock.Dal.Interfaces
{
    public interface IBaseDal<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Gets(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetAll();
    }
}
