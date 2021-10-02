using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class DataIngredientController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}