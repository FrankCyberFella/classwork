using Microsoft.AspNetCore.Mvc;

namespace gamblerapi2.Controllers.v1
{
    public class GamblerController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}