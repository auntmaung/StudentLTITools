using System.Collections.Generic;
using NUS.StudentIntegrity.Roles.Dto;

namespace NUS.StudentIntegrity.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
