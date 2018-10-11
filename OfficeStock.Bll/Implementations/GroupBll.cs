

using OfficeStock.Bll.Interfaces;
using System;
using System.Collections.Generic;
using OfficeStock.Entity;
using System.Linq.Expressions;
using OfficeStock.Dal.Implamentations;

namespace OfficeStock.Bll.Implamentations
{
    public class GroupBll : IGroupBll
    {
        public void Delete(Group group)
        {
            new GroupDal().Delete(group);
        }

        public void DeleteById(int id)
        {
            Group group= Get(x => x.Id == id);
            if (group == null)
                throw new Exception("silineceklokasyon bulunamadı");
            Delete(group);

        }

        public Group Get(Expression<Func<Group, bool>> predicate)
        {
            return new GroupDal().Get(predicate);
        }

        public IEnumerable<Group> Gets(Expression<Func<Group, bool>> predicate)
        {
            return new GroupDal().Gets(predicate);
        }

        public void Insert(Group group)
        {
            new GroupDal().Insert(group);
        }
        public IEnumerable<Group> GetAll()
        {
            return new GroupDal().GetAll();
        }
        public void Update(Group group)
        {
            new GroupDal().Update(group);
        }

   
    }
}


