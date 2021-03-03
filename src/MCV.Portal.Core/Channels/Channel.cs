using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Channels
{
   public class Channel : FullAuditedEntity
    {
        public int SubjectId { get; set; }
        public string ChannelsLink { get; set; }
        public string ChannelName { get; set; }
        public int TotalNumberOfVideos { get; set; }
        public int TotalNumberOfWatchedVideos { get; set; }
    }
}
