using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
namespace WebRazorPagesGlobalization.Models
{
    public interface IServiceLocalizer<T>
    {
        IStringLocalizer<T> StringLocalizer { get; }
        IHtmlLocalizer<T> HtmlLocalizer { get; }
        LocalizedString GetString(string name);
        LocalizedString GetHtmlString(string name);
    }
}
