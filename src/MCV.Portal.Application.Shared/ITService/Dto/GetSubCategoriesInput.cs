using System;
using System.Collections.Generic;
using System.Text;

namespace MCV.Portal.ITService.Dto
{
    public class GetSubCategoriesInput
    {
        public int Id { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual string SubCategoryName { get; set; }
    }
}
