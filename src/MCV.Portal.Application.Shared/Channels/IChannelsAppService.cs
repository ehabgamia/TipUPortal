using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MCV.Portal.Channels.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Channels
{
   public interface IChannelsAppService : IApplicationService
    {
        ListResultDto<ChannelsListDto> GetChannels(GetChannelInput input);
        Task CreateChannel(CreateChannelInput input);
        Task DeleteSubject(EntityDto input);
    }
}
