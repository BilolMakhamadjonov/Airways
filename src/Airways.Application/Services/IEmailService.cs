using Airways.Application.Models;
using Airways.Core.Entities;

namespace Airways.Application.Services
{
    public interface IEmailService
    {
        Task<ApiResult> SendEmailAsync(User user);
    }
}
