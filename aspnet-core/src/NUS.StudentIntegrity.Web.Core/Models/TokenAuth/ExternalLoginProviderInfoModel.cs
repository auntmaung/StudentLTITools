using Abp.AutoMapper;
using NUS.StudentIntegrity.Authentication.External;

namespace NUS.StudentIntegrity.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
