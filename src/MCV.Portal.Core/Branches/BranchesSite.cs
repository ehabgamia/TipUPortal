using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Branches
{
    [Table("BranchesSite")]
    public class Branche :Entity //: FullAuditedEntity
    {
        //public int Id { get; set; }
        //[Key]
        //[Column("Id")]
        public Int64 Id { get; set; }
        [Column("NAME")]
        public string NAME { get; set; }
    }
}
