

using OfficeStock.Bll.Interfaces;
using System;
using System.Collections.Generic;
using OfficeStock.Entity;
using System.Linq.Expressions;
using OfficeStock.Dal.Implamentations;

namespace OfficeStock.Bll.Implamentations
{
    public class BarcodeBll : IBarcodeBll
    {
        public void Delete(Barcode barcode)
        {
            new BarcodeDal().Delete(barcode);
        }

        public void DeleteById(int id)
        {
            Barcode barcode = Get(x => x.Id == id);
            if (barcode == null)
                throw new Exception("silineceklokasyon bulunamadı");
            Delete(barcode);

        }

        public Barcode Get(Expression<Func<Barcode, bool>> predicate)
        {
            return new BarcodeDal().Get(predicate);
        }

        public IEnumerable<Barcode> Gets(Expression<Func<Barcode, bool>> predicate)
        {
            return new BarcodeDal().Gets(predicate);
        }

        public void Insert(Barcode barcode)
        {
            new BarcodeDal().Insert(barcode);
        }
        public IEnumerable<Barcode> GetAll()
        {
            return new BarcodeDal().GetAll();
        }
        public void Update(Barcode barcode)
        {
            new BarcodeDal().Update(barcode);
        }


    }
}


