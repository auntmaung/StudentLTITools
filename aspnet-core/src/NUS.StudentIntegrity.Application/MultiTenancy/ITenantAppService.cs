using Abp.Application.Services;
using NUS.StudentIntegrity.MultiTenancy.Dto;

namespace NUS.StudentIntegrity.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

