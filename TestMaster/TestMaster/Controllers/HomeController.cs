using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestMaster.Models;

namespace TestMaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor contxt;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            contxt = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult HomePage()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return View("LoginPage");
            }
            return View();
        }
        public IActionResult CountryMaster()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return View("LoginPage");
            }
            return View();
        }
        public IActionResult StateMaster()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return View("LoginPage");
            }
            return View();
        }
        public IActionResult DistrictMaster()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return View("LoginPage");
            }
            return View();
        }
        public IActionResult CityMaster()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return View("LoginPage");
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Id");
            return View("LoginPage");
        }
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult SignupMaster()
        {
            return View();
        }   
        public IActionResult Userprofile()
        {
            return View();
        } 
        public IActionResult LastDonated()
        {
            return View();
        }
        public IActionResult SearchDonner()
        {
            return View();
        }     
        public IActionResult DonnateHistory()
        {
            return View();
        }    
        public IActionResult StatusBar()
        {
            return View();
        }
        public IActionResult ChangePassword()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}