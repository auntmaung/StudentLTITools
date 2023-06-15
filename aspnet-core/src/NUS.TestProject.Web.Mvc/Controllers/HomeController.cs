using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using NUS.TestProject.Controllers;

namespace NUS.TestProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : TestProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
