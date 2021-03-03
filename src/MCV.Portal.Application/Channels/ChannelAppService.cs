using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using MCV.Portal.Channels.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Channels
{
    public class ChannelAppService : PortalAppServiceBase, IChannelsAppService
    {
        private readonly IRepository<Channel> _channelRepository;

        public ChannelAppService(IRepository<Channel> ChannelRepository)
        {
            _channelRepository = ChannelRepository;
        }

        public async Task CreateChannel(CreateChannelInput input)
        {
            var channel = ObjectMapper.Map<Channel>(input);
            await _channelRepository.InsertAsync(channel);
        }

        public async Task DeleteSubject(EntityDto input)
        {
            await _channelRepository.DeleteAsync(input.Id);
        }

        public ListResultDto<ChannelsListDto> GetChannels(GetChannelInput input)
        {
            var channel = _channelRepository
            .GetAll()
            .OrderBy(p => p.Id)
            .ThenBy(p => p.Id)
            .ToList();

            return new ListResultDto<ChannelsListDto>(ObjectMapper.Map<List<ChannelsListDto>>(channel));
        }

        
    }
}
