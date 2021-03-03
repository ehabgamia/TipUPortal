using Abp.Application.Services.Dto;
using Abp.Webhooks;
using MCV.Portal.WebHooks.Dto;

namespace MCV.Portal.Web.Areas.App.Models.Webhooks
{
    public class CreateOrEditWebhookSubscriptionViewModel
    {
        public WebhookSubscription WebhookSubscription { get; set; }

        public ListResultDto<GetAllAvailableWebhooksOutput> AvailableWebhookEvents { get; set; }
    }
}
