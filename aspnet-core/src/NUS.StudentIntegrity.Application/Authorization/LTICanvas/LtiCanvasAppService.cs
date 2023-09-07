using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Configuration;
using Abp.Domain.Repositories;
using Abp.Organizations;
using Abp.Zero.Configuration;
using Newtonsoft.Json.Linq;
using NUS.StudentIntegrity.Authorization.LtiCanvas.Dto;
using NUS.StudentIntegrity.Authorization.Users;
using NUS.StudentIntegrity.LTICanvas;

namespace NUS.StudentIntegrity.Authorization.LtiCanvas
{
    public class LtiCanvasAppService : StudentIntegrityAppServiceBase, ILtiCanvasAppService
    {
        private readonly IRepository<Platform,int> _platformRepository;
        public LtiCanvasAppService(IRepository<Platform,int> platformRepository
            )
        {
           _platformRepository = platformRepository;
        }
        public async Task<PlatformDto> GetPlatformByIssuerAsync(string issuer)
        {
            if (string.IsNullOrWhiteSpace(issuer))
            {
                throw new ArgumentNullException(nameof(issuer));
            }

            var platForm= _platformRepository.GetAll().Where(x => x.Issuer == issuer).FirstOrDefault();
           return ObjectMapper.Map<PlatformDto>(platForm);
        }

    }
}
