using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MCV.Portal.ITService.Dto
{
  public class CreateCallsInput
    {
        public virtual string Reporter { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PCNo { get; set; }
        //public virtual string CostCenter { get; set; }
        //public virtual int ExtentionNo { get; set; }
        public virtual string Location { get; set; }
        public virtual string Problem { get; set; }
        [Required]
        public virtual string Description { get; set; }
        //public virtual string CallStatus { get; set; }
        //public virtual int ProblemByAdmin { get; set; }
        //public virtual int CatID { get; set; }

    }
}
