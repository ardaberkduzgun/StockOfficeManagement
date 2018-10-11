using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeStock.Common.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeStock.Entity
{
    [Table("FixedAssets")]
    public class FixedAsset : BaseEntity
    {
        [Required]
        [Column("OfficeStockNo")]
        [Description("DemirbasNo")]
        public int OfficeStockNo { get; set; }

        [Required]
        [Column("Description")]
        [Description("Tanım")]
        public string Description{ get; set; }

        [Column("UsageStartDate")]
        [Description("KullanımBaşlangıçTarihi")]
        public DateTime UsageStartDate { get; set; }

        [Column("ProcurementDate")]
        [Description("Temin Tarihi")]
        public DateTime ProcurementDate{ get; set; }
        
        [Column("Value")]
        [Description("Değer")]
        public double Value{ get; set; }
                
        [Required]
        [Column("BarcodeId")]
        [Description("Barkod Kayıt No")]
        public int BarcodeId { get; set; }

        [Required]
        [Column("LocationId")]
        [Description("Lokasyon Kayıt No")]
        public int LocationId { get; set; }

        [Required]
        [Column("GroupId")]
        [Description("Grup Kayıt No")]
        public int GroupId { get; set; }
    }
}