
using OfficeStock.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OfficeStock.Bll.Interfaces
{
    public interface IBaseBll<Component> where Component : BaseEntity
    {
        void Insert(Component entity);
        void Delete(Component entity);
        void Update(Component entity);
        Component Get(Expression<Func<Component, bool>> predicate);
        IEnumerable<Component> Gets(Expression<Func<Component, bool>> predicate);
    }
}
