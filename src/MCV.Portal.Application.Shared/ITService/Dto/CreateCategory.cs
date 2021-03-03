using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCV.Portal.ITService.Dto
{
    public class CreateCategory : FullAuditedEntity
    {
        public virtual string CategoryName { get; set; }
        public virtual int CategoryId { get; set; }
    }
}
