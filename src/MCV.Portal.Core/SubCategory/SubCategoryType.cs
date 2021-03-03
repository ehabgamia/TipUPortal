using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.SubCategory
{
    [Table("SubCategoryType")]
   public class SubCategoryType : FullAuditedEntity
    {
        public virtual int CategoryId { get; set; }
        public virtual string SubCategoryName { get; set; }
    }
}
