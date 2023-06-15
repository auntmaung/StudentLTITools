using System.Threading.Tasks;
using Abp.Application.Services;
using NUS.TestProject.Authorization.Accounts.Dto;

namespace NUS.TestProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
