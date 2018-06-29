using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using WebMvcCoreGlobalization.Models;

namespace WebMvcCoreGlobalization.Controllers
{
    public class HomeController : Controller
    {
        public IStringLocalizer StringLocalizer { get; }
        public IHtmlLocalizer HtmlLocalizer { get; }

        public HomeController(
            IHtmlLocalizer<HomeController> htmlLocalizer, 
            IStringLocalizer<HomeController> stringLocalizer
            )
        {
            HtmlLocalizer = htmlLocalizer;
            StringLocalizer = stringLocalizer;
        }

        public IActionResult Index()
        {
            LocalizerHomeController();
            return View();
        }        

        public IActionResult About()
        {
            LocalizerHomeController();
            return View();
        }

        public void LocalizerHomeController()
        {
            ViewData["Title"] = StringLocalizer.GetString("Title");
            ViewData["About"] = StringLocalizer.GetString("About");
        }

        [HttpPost]
        public IActionResult OnPostLanguage(string culture, string returnUrl = "/")
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
