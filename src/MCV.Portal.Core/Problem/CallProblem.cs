using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Problem
{
    [Table ("CallsProblems")]
   public class CallProblem : Entity
    {
        public Int64 Id { get; set; }
        public Int64 CATEGORYID { get; set; }
        public string ProblemCat { get; set; }
        public string CATEGORYDESCRIPTION { get; set; }
        public string ProblemSubCat { get; set; }
        public string DESCRIPTION { get; set; }
        public bool Del { get; set; }

    }
}
