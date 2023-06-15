using System.Collections.Generic;
using NUS.TestProject.Roles.Dto;

namespace NUS.TestProject.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
