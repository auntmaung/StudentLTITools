using System.Threading.Tasks;
using Abp.Application.Services;
using NUS.StudentIntegrity.Authorization.Accounts.Dto;
using NUS.StudentIntegrity.Authorization.LtiCanvas.Dto;

namespace NUS.StudentIntegrity.Authorization.LtiCanvas
{
    public interface ILtiCanvasAppService : IApplicationService
    {
        Task<PlatformDto> GetPlatformByIssuerAsync(string issuer);
    }
}
