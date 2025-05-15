using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementApp.Views
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
