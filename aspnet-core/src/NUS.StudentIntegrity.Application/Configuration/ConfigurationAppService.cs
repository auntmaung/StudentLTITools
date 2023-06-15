using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using NUS.StudentIntegrity.Configuration.Dto;

namespace NUS.StudentIntegrity.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : StudentIntegrityAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
