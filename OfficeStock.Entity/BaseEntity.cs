using OfficeStock.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeStock.Entity
{
    public class BaseEntity
    {
        [Key]
        [Column("Id")]
        [Description("Kaydın tekil numarası")]
        public int Id { get; set; }

   

        [Required]
        [Range(-1, 9)]
        [Column("Statu")]
        [Description("Kaydın statüsü")]
        public virtual Statu Statu { get; set; } = Statu.Active;
    }
}