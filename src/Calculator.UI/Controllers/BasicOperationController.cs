namespace Calculator.UI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BasicOperationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add(int a, int b)
        {
            throw new NotImplementedException();
        }
    }
}
