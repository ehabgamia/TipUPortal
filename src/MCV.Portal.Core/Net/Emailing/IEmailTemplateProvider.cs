namespace MCV.Portal.Net.Emailing
{
    public interface IEmailTemplateProvider
    {
        string GetDefaultTemplate(int? tenantId);
        string GetDefaultNotitificationTemplate(int? tenantId, string title, string subtitle, string body, string link,bool IsApproved);
        string GetConfirmationNotitificationTemplate(int? tenantId, string title, string subtitle, string body);
    }
}
