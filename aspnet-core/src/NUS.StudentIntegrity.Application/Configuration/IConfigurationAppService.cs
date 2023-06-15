using System.Threading.Tasks;
using NUS.StudentIntegrity.Configuration.Dto;

namespace NUS.StudentIntegrity.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
