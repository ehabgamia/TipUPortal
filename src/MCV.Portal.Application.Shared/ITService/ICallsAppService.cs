using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MCV.Portal.Authorization.Users.Dto;
using MCV.Portal.ITService.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.ITService
{
   public interface ICallsAppService : IApplicationService
    {
        //Task<ListResultDto<UserListDto>> GetUserInfo(GetUsersInput input);
        //ListResultDto<CallsListDto> GetCalls(GetCallsInput input);
        Task CreateCalls(CreateCallsInput input);
        Task DeleteCalls(EntityDto input);
        Task RejReqServ(int Id);
        Task ApprReqServ(int Id);

    }
}
