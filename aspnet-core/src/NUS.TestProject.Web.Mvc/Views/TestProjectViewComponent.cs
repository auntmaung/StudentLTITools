using Abp.AspNetCore.Mvc.ViewComponents;

namespace NUS.TestProject.Web.Views
{
    public abstract class TestProjectViewComponent : AbpViewComponent
    {
        protected TestProjectViewComponent()
        {
            LocalizationSourceName = TestProjectConsts.LocalizationSourceName;
        }
    }
}
