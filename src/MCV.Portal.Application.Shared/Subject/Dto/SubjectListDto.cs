using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCV.Portal.Subject.Dto
{
   public class SubjectListDto : FullAuditedEntity
    {
        public virtual string SubjectName { get; set; }
        public virtual TimeSpan MinsToWatch { get; set; }
        public virtual string Reward { get; set; }
    }
}
