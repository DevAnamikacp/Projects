using Microsoft.AspNetCore.Mvc;
using UserProject.Models;
using System.Diagnostics;
using UserProject.Models.Dal;
using System.Data;
using UserProject.Controllers;
using Microsoft.AspNetCore.Http;

namespace SessionAsp.Controllers
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
        if(HttpContext.Session.GetInt32("Id")==null)
            {
            RedirectToAction("Login");
            }
          
            return View();
        }
        public IActionResult Login()
        {
           
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Id");
            return View("Login");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult AdminHomePage(SigninModel obj)
        {
            //if (HttpContext.Session.GetInt32("Id") == null)
            //{
            //    RedirectToAction("Login");
            //}
            HttpContext.Session.Remove("TYId");

            return View("Login");
        }
        public IActionResult UserHomePage(SigninModel obj)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                RedirectToAction("Login");
            }
            return View();
        }  
        public IActionResult SuperUserPage(SigninModel obj)
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                RedirectToAction("Login");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}














