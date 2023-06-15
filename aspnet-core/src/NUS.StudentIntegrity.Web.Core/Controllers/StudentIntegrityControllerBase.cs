using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace NUS.StudentIntegrity.Controllers
{
    public abstract class StudentIntegrityControllerBase: AbpController
    {
        protected StudentIntegrityControllerBase()
        {
            LocalizationSourceName = StudentIntegrityConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
