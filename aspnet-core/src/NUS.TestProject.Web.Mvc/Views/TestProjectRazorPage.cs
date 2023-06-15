using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace NUS.TestProject.Web.Views
{
    public abstract class TestProjectRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected TestProjectRazorPage()
        {
            LocalizationSourceName = TestProjectConsts.LocalizationSourceName;
        }
    }
}
