using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using WebRazorPagesGlobalization.Models;

namespace WebRazorPagesGlobalization.Pages
{
    public class IndexModel : PageModel
    {
        public IServiceLocalizerIndexModel Localizer { get; }
        public IndexModel(IServiceLocalizerIndexModel localizer)
        {            
            Localizer = localizer;
        }       

        public void OnGet()
        {
            ViewData["Title"] = Localizer.GetString("Title");
        }

        [HttpPost]
        public IActionResult OnPostLanguage(string culture, string returnUrl = "/Index")
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}

//WebRazorPagesGlobalization.Resources.Pages.IndexModel
