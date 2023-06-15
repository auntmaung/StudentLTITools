using Abp.AutoMapper;
using NUS.StudentIntegrity.Roles.Dto;
using NUS.StudentIntegrity.Web.Models.Common;

namespace NUS.StudentIntegrity.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
