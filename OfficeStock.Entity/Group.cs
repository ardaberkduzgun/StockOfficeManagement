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
    [Table("Groups")]
    public class Group : BaseEntity
    {
        [Required]
        [Column("GroupName")]
        [Description("GrupIsmi")]
        public string Name{ get; set; }
        /*enumu özellik olarak tanımam lazım*/
        
        [Required]
        [Column("GroupCode")]
        [Description("GrupKodu")]
        public string GroupCode { get; set; }
    }
}