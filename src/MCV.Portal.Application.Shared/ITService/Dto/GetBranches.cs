using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MCV.Portal.ITService.Dto
{
   public class GetBranches   //: FullAuditedEntity
    {
        
        public Int64 Id { get; set; }
        public string NAME { get; set; }
    }
}
