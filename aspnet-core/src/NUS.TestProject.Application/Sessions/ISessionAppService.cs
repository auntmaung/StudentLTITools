using System.Threading.Tasks;
using Abp.Application.Services;
using NUS.TestProject.Sessions.Dto;

namespace NUS.TestProject.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
