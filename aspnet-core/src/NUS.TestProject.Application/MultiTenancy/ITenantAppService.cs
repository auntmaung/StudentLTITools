using Abp.Application.Services;
using NUS.TestProject.MultiTenancy.Dto;

namespace NUS.TestProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

