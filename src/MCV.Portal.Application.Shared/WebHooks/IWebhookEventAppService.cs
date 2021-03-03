using System.Threading.Tasks;
using Abp.Webhooks;

namespace MCV.Portal.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
