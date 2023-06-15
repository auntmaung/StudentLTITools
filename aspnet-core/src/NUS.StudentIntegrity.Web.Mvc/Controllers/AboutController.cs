using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using NUS.StudentIntegrity.Controllers;

namespace NUS.StudentIntegrity.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : StudentIntegrityControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
