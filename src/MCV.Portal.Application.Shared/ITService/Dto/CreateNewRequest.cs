using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MCV.Portal.ITService.Dto
{
   public class CreateNewRequest
    {
        public virtual string Reporter { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual string UserName { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int SubCategoryId { get; set; }
        //public virtual string CategoryName { get; set; }
        //public virtual string SubCtegoryName { get; set; }
        public virtual string PCNo { get; set; }
        public virtual string LocationTypeID { get; set; }
        public virtual string Subject { get; set; }
        [Required]
        public virtual string Description { get; set; }
        public string UploadPathFile { get; set; }

    }
}
