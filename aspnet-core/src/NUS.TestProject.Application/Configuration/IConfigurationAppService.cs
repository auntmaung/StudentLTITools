using System.Threading.Tasks;
using NUS.TestProject.Configuration.Dto;

namespace NUS.TestProject.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
