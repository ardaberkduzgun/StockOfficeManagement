using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeStock.Entity
{
    [Table("Barcodes")]
    public class Barcode : BaseEntity
    {
        public string code { get; set; }
    }
}
