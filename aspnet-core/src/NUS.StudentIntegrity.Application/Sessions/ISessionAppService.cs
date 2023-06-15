using System.Threading.Tasks;
using Abp.Application.Services;
using NUS.StudentIntegrity.Sessions.Dto;

namespace NUS.StudentIntegrity.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
