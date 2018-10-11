
using OfficeStock.Entity;

namespace OfficeStock.Bll.Interfaces
{
    public interface IBarcodeBll : IBaseBll<Barcode>
    {
        void DeleteById(int id);
    }
}




