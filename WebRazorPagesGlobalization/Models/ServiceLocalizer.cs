using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using WebRazorPagesGlobalization.Pages;

namespace WebRazorPagesGlobalization.Models
{
    public abstract class ServiceLocalizer<T>: IServiceLocalizer<T>
    {
        public IStringLocalizer<T> StringLocalizer { get; }
        public IHtmlLocalizer<T> HtmlLocalizer { get; }

        public ServiceLocalizer(IStringLocalizer<T> stringLocalizer, IHtmlLocalizer<T> htmlLocalizer)
        {
            StringLocalizer = stringLocalizer;
            HtmlLocalizer = htmlLocalizer;
        }

        public LocalizedString GetString(string name)
        {
            return StringLocalizer.GetString(name);
        }

        public LocalizedString GetHtmlString(string name)
        {
            return HtmlLocalizer.GetString(name);
        }
    }

    public interface IServiceLocalizerIndexModel: IServiceLocalizer<IndexModel> { }

    public class ServiceLocalizerIndexModel : ServiceLocalizer<IndexModel>, IServiceLocalizerIndexModel
    {
        public ServiceLocalizerIndexModel(
            IStringLocalizer<IndexModel> stringLocalizer, 
            IHtmlLocalizer<IndexModel> htmlLocalizer) 
            : base(stringLocalizer, htmlLocalizer)
        {
        }
    }
}
