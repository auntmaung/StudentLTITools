using System.Collections.Generic;
using NUS.StudentIntegrity.Roles.Dto;

namespace NUS.StudentIntegrity.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
