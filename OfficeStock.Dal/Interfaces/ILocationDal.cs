using OfficeStock.Common.Repository;
using OfficeStock.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeStock.Dal.Interfaces
{
    public interface ILocationDal : IBaseDal<Location>
    {
        PagingResponse<Location> GetLocationList(PagingRequest request);
        List<Location> GetByParentId(int id);
        void VirtualDelete(Location location);
        void VirtualDelete(int locationId);
        void DeleteHierarchy(Location location);
    }
}


