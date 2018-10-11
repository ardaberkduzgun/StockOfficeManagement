using System;
using System.Collections.Generic;
using System.Linq;


using OfficeStock.Dal.Contexts;
using OfficeStock.Dal.Interfaces;
using OfficeStock.Entity;
using System.Linq.Expressions;
using LinqKit;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace OfficeStock.Dal.Implamentations
{
    public class GroupDal : IGroupDal
    {

        public GroupDal() : base() { }

        public void Delete(Group group)
        {

            using (AssociationDbContext context = new AssociationDbContext())
            {

                context.Entry(group).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public Group Get(Expression<Func<Group, bool>> predicate)
        {
            Group group = null;
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    group = context.Groups.Where(predicate).FirstOrDefault();
                }

            }
            catch
            {
                throw;
            }
            return group;
        }

        public IEnumerable<Group> GetAll()
        {
            List<Group> list = new List<Group>();
            using (AssociationDbContext context = new AssociationDbContext())
            {
                list = context.Groups.ToList();
            }
            return list; throw new NotImplementedException();
        }

        public IEnumerable<Group> Gets(Expression<Func<Group, bool>> predicate)
        {
            List<Group> list = new List<Group>();
            using (AssociationDbContext context = new AssociationDbContext())
            {
                list = context.Groups.AsExpandable().Where(predicate).ToList();
            }
            return list;
        }

        public void Create(Group group)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    context.Groups.Add(group);
                    context.SaveChanges();
                };
            }
            catch
            {
                throw;
            }
        }


        public void Update(Group group)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    if (context.Entry(group).State == EntityState.Detached)
                        context.Set<Group>().Attach(group);

                    context.Entry(group).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }
        
          public void Insert(Group group)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    context.Groups.Add(group);
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
             /*
        public void Insert(Group entity)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    context.Groups.Add(entity);
                    context.SaveChanges();
                };
            }
            catch
            {
                throw;
            }*/
        }
    }

 
      
 