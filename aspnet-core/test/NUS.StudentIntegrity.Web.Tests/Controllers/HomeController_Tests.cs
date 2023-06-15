using System.Threading.Tasks;
using NUS.StudentIntegrity.Models.TokenAuth;
using NUS.StudentIntegrity.Web.Controllers;
using Shouldly;
using Xunit;

namespace NUS.StudentIntegrity.Web.Tests.Controllers
{
    public class HomeController_Tests: StudentIntegrityWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}