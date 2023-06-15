using System.Collections.Generic;
using NUS.TestProject.Roles.Dto;

namespace NUS.TestProject.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}