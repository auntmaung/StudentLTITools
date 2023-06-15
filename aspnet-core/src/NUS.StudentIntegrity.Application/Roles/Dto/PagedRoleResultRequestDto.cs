using Abp.Application.Services.Dto;

namespace NUS.StudentIntegrity.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

