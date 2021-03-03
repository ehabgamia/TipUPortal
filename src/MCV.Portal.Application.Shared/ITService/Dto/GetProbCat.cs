using System;
using System.Collections.Generic;
using System.Text;

namespace MCV.Portal.ITService.Dto
{
   public class GetProbCat
    {
        //public Int64 CATEGORYID { get; set; }
        public string ProblemCat { get; set; }
        public Int64 Id { get; set; }
        public string ProblemSubCat { get; set; }
        
        //public string CATEGORYDESCRIPTION { get; set; }
        //public string DESCRIPTION { get; set; }
        //public bool Del { get; set; }
    }
}
