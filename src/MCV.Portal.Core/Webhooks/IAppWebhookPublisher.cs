using System.Threading.Tasks;
using MCV.Portal.Authorization.Users;

namespace MCV.Portal.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
