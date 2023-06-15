using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace NUS.StudentIntegrity.Web.Views
{
    public abstract class StudentIntegrityRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected StudentIntegrityRazorPage()
        {
            LocalizationSourceName = StudentIntegrityConsts.LocalizationSourceName;
        }
    }
}
