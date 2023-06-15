using System.Collections.Generic;
using NUS.TestProject.Roles.Dto;

namespace NUS.TestProject.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
