using Abp.BackgroundJobs;
using MCV.Portal.Storage;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCV.Portal.Web.Controllers
{
    public class PhoneBookController : PortalControllerBase
    {
        public PhoneBookController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base()
        {
        }
    }
}
