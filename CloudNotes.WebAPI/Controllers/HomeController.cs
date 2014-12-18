using System.Web.Mvc;

namespace CloudNotes.WebAPI.Controllers
{
    /// <summary>
    /// Represents the Home Controller
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/> value.</returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
