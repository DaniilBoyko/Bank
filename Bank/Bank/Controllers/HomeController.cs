using System.Web.Mvc;

namespace Bank.Controllers
{
    /// <summary>
    /// Controller for home.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Get index page.
        /// </summary>
        /// <returns>Index page.</returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Get about page.
        /// </summary>
        /// <returns>About page.</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        /// <summary>
        /// Get contact page.
        /// </summary>
        /// <returns>Contact page.</returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}