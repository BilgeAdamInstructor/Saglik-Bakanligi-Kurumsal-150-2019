using Microsoft.AspNetCore.Mvc;

namespace JwtExercise.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
    //localhost:5000/main/index 
    