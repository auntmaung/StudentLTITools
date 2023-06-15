using Abp.AspNetCore.Mvc.ViewComponents;

namespace NUS.StudentIntegrity.Web.Views
{
    public abstract class StudentIntegrityViewComponent : AbpViewComponent
    {
        protected StudentIntegrityViewComponent()
        {
            LocalizationSourceName = StudentIntegrityConsts.LocalizationSourceName;
        }
    }
}
