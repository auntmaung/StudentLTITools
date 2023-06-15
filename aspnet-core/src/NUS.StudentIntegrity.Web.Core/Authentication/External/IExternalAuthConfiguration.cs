using System.Collections.Generic;

namespace NUS.StudentIntegrity.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
