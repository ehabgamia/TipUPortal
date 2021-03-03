using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCV.Portal.Channels.Dto
{
   public class ChannelsListDto : FullAuditedEntity
    {
        public int SubjectId { get; set; }
        public string ChannelsLink { get; set; }
        public string ChannelName { get; set; }
        public int TotalNumberOfVideos { get; set; }
        public int TotalNumberOfWatchedVideos { get; set; }
    }
}
