
using System;
using System.Collections.Generic;
using System.Linq;


using OfficeStock.Dal.Contexts;
using OfficeStock.Entity;
using System.Linq.Expressions;
using System.Data.Entity.Validation;
using System.Data.Entity;
using OfficeStock.Dal.Interfaces;
using LinqKit;
using OfficeStock.Common.Repository;
using OfficeStock.Dal.Implamentations;

namespace OfficeStock.Dal.Implamentations
{
    public class LocationDal : ILocationDal
    {

        public LocationDal() : base() { }


        public void Delete(Location location)
        {

            using (AssociationDbContext context = new AssociationDbContext())
            {
                context.Entry(location).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void DeleteHierarchy(Location location)
        {
            List<Location> list = Gets(x => x.ParentId == location.Id).ToList();
            foreach (Location item in list)
            {
                Location l = Get(x => x.ParentId == item.Id);
                if (l != null)
                    DeleteHierarchy(l);
                else
                    Delete(item);
            }
            Delete(location);
        }

        public Location Get(Expression<Func<Location, bool>> predicate)
        {
            Location location = null;
            try
            {

                using (AssociationDbContext context = new AssociationDbContext())
                {
                    location = context.Locations.Where(predicate).FirstOrDefault();
                }

            }
            catch
            {
                throw;
            }
            return location;
        }

        public IEnumerable<Location> GetAll()
        {
            List<Location> list = new List<Location>();
            using (AssociationDbContext context = new AssociationDbContext())
            {
                list = context.Locations.ToList();
            }
            return list; throw new NotImplementedException();
        }

        public void Updatee(Location location)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    if (context.Entry(location).State == EntityState.Detached)
                        context.Set<Location>().Attach(location);

                    context.Entry(location).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<Location> GetByParentId(int id)
        {
            throw new NotImplementedException();
        }

        public PagingResponse<Location> GetLocationList(PagingRequest request)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> Gets(Expression<Func<Location, bool>> predicate)
        {
            List<Location> list = new List<Location>();
            using (AssociationDbContext context = new AssociationDbContext())
            {
                list = context.Locations.AsExpandable().Where(predicate).ToList();
                list.ForEach(location =>
                {
                    if (Get(x => x.ParentId == location.Id) != null)
                        location.HasChild = true;
                });
            }
            return list;
        }

        public void Insert(Location location)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    context.Locations.Add(location);
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

        public void Update(Location location)
        {
            try
            {
                using (AssociationDbContext context = new AssociationDbContext())
                {
                    if (context.Entry(location).State == EntityState.Detached)
                        context.Set<Location>().Attach(location);

                    context.Entry(location).State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        public void VirtualDelete(int locationId)
        {
            throw new NotImplementedException();
        }

        public void VirtualDelete(Location location)
        {
            throw new NotImplementedException();
        }
    }
}



