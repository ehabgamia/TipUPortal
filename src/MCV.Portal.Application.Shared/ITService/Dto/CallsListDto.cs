using Abp.Application.Services.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MCV.Portal.ITService.Dto
{
   public class CallsListDto : FullAuditedEntityDto
    {
        public virtual string Reporter { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PCNo { get; set; }
        public virtual int LocationTypeID { get; set; }
        public virtual string Description { get; set; }
        public virtual string Subject { get; set; }
        
        public virtual DateTime Date { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int SubCategoryId { get; set; }
        public string Status { get; set; }
    }
}
