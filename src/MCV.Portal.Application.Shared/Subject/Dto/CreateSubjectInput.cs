using System;
using System.Collections.Generic;
using System.Text;

namespace MCV.Portal.Subject.Dto
{
   public class CreateSubjectInput
    {
        public virtual string SubjectName { get; set; }
        public virtual string Reward { get; set; }
        public virtual int UserId { get; set; }
    }
}
