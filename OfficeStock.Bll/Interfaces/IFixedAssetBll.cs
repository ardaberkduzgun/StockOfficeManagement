
using OfficeStock.Entity;

namespace OfficeStock.Bll.Interfaces
{
    public interface IFixedAssetBll : IBaseBll<FixedAsset>
    {
        void DeleteById(int id);
    }
}




