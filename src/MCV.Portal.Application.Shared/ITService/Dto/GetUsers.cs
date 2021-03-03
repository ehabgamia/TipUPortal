using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCV.Portal.ITService.Dto
{
   public class GetUsers 
    {
        public int Id { get; set; }
        public virtual string UserName { get; set; }

    }
}
