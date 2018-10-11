using System;
using System.Collections.Generic;
using System.Linq;


using OfficeStock.Dal.Contexts;
using OfficeStock.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Validation;
using System.Data.Entity;

using LinqKit;
using OfficeStock.Dal.Interfaces;

namespace OfficeStock.Dal.Implamentations
{
    public class BarcodeDal : IBarcodeDal
    {

        public BarcodeDal() : base() { }

        public void Delete(Barcode barcode)
        {

            using (AssociationDbContext context = new AssociationDbContext())
            {

                context.Entry(barcode).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Barcode Get(Expression<Func<Barcode, bool>> predicate)
        {
            Barcode barcode = null;
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    barcode = context.Barcodes.Where(predicate).FirstOrDefault();
                }

            }
            catch
            {
                throw;
            }
            return barcode;
        }

        public IEnumerable<Barcode> GetAll()
        {
            List<Barcode> list = new List<Barcode>();
            using (AssociationDbContext context = new AssociationDbContext())
            {
                list = context.Barcodes.ToList();
            }
            return list; throw new NotImplementedException();
        }

        public IEnumerable<Barcode> Gets(Expression<Func<Barcode, bool>> predicate)
        {
            List<Barcode> list = new List<Barcode>();
            using (AssociationDbContext context = new AssociationDbContext())
            {
                list = context.Barcodes.AsExpandable().Where(predicate).ToList();
            }
            return list;
        }

        public void Insert(Barcode barcode)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    context.Barcodes.Add(barcode);
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

        public void Update(Barcode barcode)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    if (context.Entry(barcode).State == EntityState.Detached)
                        context.Set<Barcode>().Attach(barcode);

                    context.Entry(barcode).State = EntityState.Modified;
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

