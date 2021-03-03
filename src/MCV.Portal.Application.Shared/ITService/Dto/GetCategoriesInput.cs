using System;
using System.Collections.Generic;
using System.Text;

namespace MCV.Portal.ITService.Dto
{
   public class GetCategoriesInput 
    {
        public virtual int CategoryId { get; set; }
        //public virtual int SubCategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        //public virtual string SubCtegoryName { get; set; }
    }
}
