
using OfficeStock.Common.Repository;
using OfficeStock.Entity;
using System.Collections.Generic;

namespace OfficeStock.Bll.Interfaces
{
    public interface ILocationBll : IBaseBll<Location>
    {
        PagingResponse<Location> GetLocationList(PagingRequest request);
        List<Location> GetByParentId(int id);
        void VirtualDelete(int id);
        IEnumerable<Location> GetAll();
        void DeleteById(int id);
        void DeleteHierarchy(int id);
    }
}



      
  