using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.CategoryService
{
    [Table("CategoriesService")]
    public class CategoryServe : Entity
    {
        public Int64 Id { get; set; }
        //public Int64 CATEGORYID { get; set; }
        public string ProblemCat { get; set; }
        public string CATEGORYDESCRIPTION { get; set; }
    }
}
