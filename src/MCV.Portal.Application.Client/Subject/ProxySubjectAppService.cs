using Abp.Application.Services.Dto;
using MCV.Portal.Subject.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Subject
{
    public class ProxySubjectAppService : ProxyAppServiceBase, ISubjectAppService
    {
        public Task CreateSubject(CreateSubjectInput input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSubject(EntityDto input)
        {
            throw new NotImplementedException();
        }

        public async Task<ListResultDto<SubjectListDto>> GetSubject() //GetSubjectInput input
        {
            return await ApiClient.GetAsync<ListResultDto<SubjectListDto>>(GetEndpoint(nameof(GetSubject)));
        }
    }
}
