using System.Threading.Tasks;
using Abp.ObjectMapping;
using NUS.TestProject.Sessions;
using Microsoft.AspNetCore.Mvc;

namespace NUS.TestProject.Web.Views.Shared.Components.TenantChange
{
    public class TenantChangeViewComponent : TestProjectViewComponent
    {
        private readonly ISessionAppService _sessionAppService;
        private readonly IObjectMapper _objectMapper;

        public TenantChangeViewComponent(ISessionAppService sessionAppService, IObjectMapper objectMapper)
        {
            _sessionAppService = sessionAppService;
            _objectMapper = objectMapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loginInfo = await _sessionAppService.GetCurrentLoginInformations();
            var model = _objectMapper.Map<TenantChangeViewModel>(loginInfo);
            return View(model);
        }
    }
}
