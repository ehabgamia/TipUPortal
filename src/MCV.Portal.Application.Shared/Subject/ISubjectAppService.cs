using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MCV.Portal.Subject.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Subject
{
   public interface ISubjectAppService : IApplicationService
    {
       Task<ListResultDto<SubjectListDto>> GetSubject(GetSubjectInput input);
        Task CreateSubject(CreateSubjectInput input);
        Task DeleteSubject(EntityDto input);
    }
}
