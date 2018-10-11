
using OfficeStock.Entity;

namespace OfficeStock.Bll.Interfaces
{
    public interface IGroupBll : IBaseBll<Group>
    {
        void DeleteById(int id);
    }
}




