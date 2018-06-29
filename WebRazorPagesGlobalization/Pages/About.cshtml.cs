using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace WebRazorPagesGlobalization.Pages
{
    public class AboutModel : PageModel
    {
        public IStringLocalizer StringLocalizer { get; }
        public IHtmlLocalizer HtmlLocalizer { get; }

        public AboutModel(IHtmlLocalizer<AboutModel> htmlLocalizer, IStringLocalizer<AboutModel> stringLocalizer)
        {
            HtmlLocalizer = htmlLocalizer;
            StringLocalizer = stringLocalizer;

        }
        public void OnGet()
        {
            ViewData["Title"] = StringLocalizer.GetString("Title");
        }
    }
}