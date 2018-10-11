

using OfficeStock.Bll.Interfaces;
using System;
using System.Collections.Generic;
using OfficeStock.Entity;
using System.Linq.Expressions;
using OfficeStock.Dal.Implamentations;

namespace OfficeStock.Bll.Implamentations
{
    public class FixedAssetBll : IFixedAssetBll
    {
        public void Delete(FixedAsset fixedAsset)
        {
            new FixedAssetDal().Delete(fixedAsset);
        }
        public IEnumerable<FixedAsset> GetAll()
        {
            return new FixedAssetDal().GetAll();
        }
        public FixedAsset Get(Expression<Func<FixedAsset, bool>> predicate)
        {
            return new FixedAssetDal().Get(predicate);
        }
        public void DeleteById(int id)
        {
            FixedAsset fixedAsset = Get(x => x.Id == id);
            if (fixedAsset == null)
                throw new Exception("silineceklokasyon bulunamadı");
            Delete(fixedAsset);

        }
        public IEnumerable<FixedAsset> Gets(Expression<Func<FixedAsset, bool>> predicate)
        {
            return new FixedAssetDal().Gets(predicate);
        }

        public void Insert(FixedAsset donation)
        {
            new FixedAssetDal().Insert(donation);
        }

        public void Update(FixedAsset donation)
        {
            new FixedAssetDal().Update(donation);
        }
    }
}


