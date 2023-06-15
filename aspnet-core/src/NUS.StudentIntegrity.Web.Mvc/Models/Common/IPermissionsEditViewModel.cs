using System.Collections.Generic;
using NUS.StudentIntegrity.Roles.Dto;

namespace NUS.StudentIntegrity.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}