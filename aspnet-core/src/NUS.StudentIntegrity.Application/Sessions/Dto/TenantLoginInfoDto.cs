using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using NUS.StudentIntegrity.MultiTenancy;

namespace NUS.StudentIntegrity.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
