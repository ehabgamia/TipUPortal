using System.Threading.Tasks;
using Abp.Application.Services;
using MCV.Portal.MultiTenancy.Payments.Dto;
using MCV.Portal.MultiTenancy.Payments.Stripe.Dto;

namespace MCV.Portal.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}