using System.Web.Mvc;

namespace PairingTest.Web.Controllers
{
    public class TemplateController : BaseController
    {
        public PartialViewResult Render(string feature, string name)
        {
            return PartialView(string.Format("~/scripts/app/{0}/templates/{1}", feature, name));
        }
    }
}