using Abp.AutoMapper;
using NUS.StudentIntegrity.Sessions.Dto;

namespace NUS.StudentIntegrity.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
