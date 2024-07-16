using InternetScool.BLL.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InternetSchoolFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISchoolService _schoolService;

        public HomeController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        public IActionResult Index()
        {
            return View(_schoolService.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
