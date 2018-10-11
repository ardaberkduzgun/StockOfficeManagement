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
    [Table("Locations")]
    public class Location : BaseEntity
    {
        [Required]
        [Column("LocationName")]
        [Description("KonumIsmi")]
        public string Name { get; set; }
        
        [Column("LocationDecription")]
        [Description("KonumAciklama")]
        public string Description { get; set; }

        [Column("ParentId")]
        [Description("ParentId")]
        public int ParentId { get; set; }

        [NotMapped]
        public bool HasChild { get; set; } = false;


    }
}