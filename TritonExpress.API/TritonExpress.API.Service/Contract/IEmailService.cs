using System.Threading.Tasks;
using TritonExpress.API.Domain.Settings;

namespace TritonExpress.API.Service.Contract
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);

    }
}
