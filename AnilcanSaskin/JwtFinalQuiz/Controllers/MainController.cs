using Microsoft.AspNetCore.Mvc;

namespace JwtFinalQuiz.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}