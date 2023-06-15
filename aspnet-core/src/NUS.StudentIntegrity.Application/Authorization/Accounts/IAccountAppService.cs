using System.Threading.Tasks;
using Abp.Application.Services;
using NUS.StudentIntegrity.Authorization.Accounts.Dto;

namespace NUS.StudentIntegrity.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
