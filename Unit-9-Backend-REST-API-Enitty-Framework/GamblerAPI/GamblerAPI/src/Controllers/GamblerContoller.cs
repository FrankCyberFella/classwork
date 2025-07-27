using Microsoft.AspNetCore.Mvc;

namespace gamblerapi.Controllers
{
    public class GamblerContoller : Controller
    {
        
        [Route("api/v1/[controller]")]
        public IActionResult Index()
        {
            return Ok("Welcome to Frank's Controller");
        }
    }
}