using Abp.Domain.Entities.Auditing;
using MCV.Portal.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Subjects
{
   public class Subject : FullAuditedEntity
    {
        public virtual string SubjectName { get; set; }
        public virtual TimeSpan MinsToWatch { get; set; }
        public virtual string Reward { get; set; }
        public virtual ICollection<User> User { get; set; }
        public virtual int UserId { get; set; }
    }
}
