using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Category
{
    [Table("Categories")]
   public class Categories :FullAuditedEntity
    {
        public virtual int CategoryId { get; set; }
        //public virtual int SubCategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        //public virtual string SubCtegoryName { get; set; }
    }
}
