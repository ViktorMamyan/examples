using System.Web.Mvc;

namespace Secure.Controllers
{
    public class SecureController : Controller
    {
        [ValidateInput(false)]
        public ActionResult Index()
        {
            /*
             * to disallow default allert on xss
             * [ValidateInput(false)]
             * 
             * to install package use
             * Install-Package AntiXSS
             * command
            */

            if (ModelState.IsValid)
            {
                //cleaning ansafe code
                string safeString = Microsoft.Security.Application.Sanitizer.GetSafeHtmlFragment("<b>Hello</b>");
            }

            return View();
        }
    }
}