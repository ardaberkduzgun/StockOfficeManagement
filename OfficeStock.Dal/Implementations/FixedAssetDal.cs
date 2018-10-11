using System;
using System.Collections.Generic;
using System.Linq;


using OfficeStock.Dal.Contexts;
using OfficeStock.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Validation;
using System.Data.Entity;

using LinqKit;


namespace OfficeStock.Dal.Implamentations
{
    public class FixedAssetDal : IFixedAssetDal
    {

        public FixedAssetDal() : base() { }

        public void Delete(FixedAsset fixedAsset)
        {

            using (AssociationDbContext context = new AssociationDbContext())
            {

                context.Entry(fixedAsset).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public FixedAsset Get(Expression<Func<FixedAsset, bool>> predicate)
        {
            FixedAsset fixedAsset = null;
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    fixedAsset = context.FixedAssets.Where(predicate).FirstOrDefault();
                }

            }
            catch
            {
                throw;
            }
            return fixedAsset;
        }

        public IEnumerable<FixedAsset> GetAll()
        {
            List<FixedAsset> list = new List<FixedAsset>();
            using (AssociationDbContext context = new AssociationDbContext())
            {
                list = context.FixedAssets.ToList();
            }
            return list; throw new NotImplementedException();
        }

        public IEnumerable<FixedAsset> Gets(Expression<Func<FixedAsset, bool>> predicate)
        {
            List<FixedAsset> list = new List<FixedAsset>();
            using (AssociationDbContext context = new AssociationDbContext())
            {
                list=context.FixedAssets.AsExpandable().Where(predicate).ToList();
            }
            return list;
        }

        public void Insert(FixedAsset fixedAsset)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    context.FixedAssets.Add(fixedAsset);
                    context.SaveChanges();
                };
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                    }
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public void Update(FixedAsset fixedAsset)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    if (context.Entry(fixedAsset).State == EntityState.Detached)
                        context.Set<FixedAsset>().Attach(fixedAsset);

                    context.Entry(fixedAsset).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}

