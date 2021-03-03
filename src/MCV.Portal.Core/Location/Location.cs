using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Location
{
    [Table("LocationType")]
   public class LocationType : FullAuditedEntity
    {
        public int LocationTypeID { get; set; }
        public string LocationName { get; set; }
    }
}
