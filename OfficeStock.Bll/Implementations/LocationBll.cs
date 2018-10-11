

using OfficeStock.Bll.Interfaces;
using System;
using System.Collections.Generic;
using OfficeStock.Entity;
using System.Linq.Expressions;
using OfficeStock.Dal.Implamentations;
using OfficeStock.Common.Repository;

namespace OfficeStock.Bll.Implamentations
{
    public class LocationBll : ILocationBll
    {
        public void Delete(Location location)
        {
            new LocationDal().Delete(location);
        }

        public void DeleteHierarchy(int id)
        {
            Location location = Get(x=>x.Id==id);
            new LocationDal().DeleteHierarchy(location);
        }
        public Location Get(Expression<Func<Location, bool>> predicate)
        {
            return new LocationDal().Get(predicate);
        }

        public void DeleteById(int id)
        {
            Location location = Get(x => x.Id == id);
            if (location == null)
                throw new Exception("silineceklokasyon bulunamadı");
            Delete(location);

        }
        public IEnumerable<Location> GetAll()
        {
            return new LocationDal().GetAll();
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
            return new LocationDal().Gets(predicate);
        }

        public void Insert(Location location)
        {
            new LocationDal().Insert(location);
        }

        public void Update(Location location)
        {
            new LocationDal().Update(location);
        }

        public void VirtualDelete(int id)
        {
            throw new NotImplementedException();
        }
        public void Updatee(Location location)
        {
            new LocationDal().Updatee(location);
        }


    }
}


