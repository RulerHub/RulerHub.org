using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace RulerHub.Controllers;

[Route("[controller]/[action]")]
public class CultureController : Controller
{
    public IActionResult Set(string culture, string redirectUri)
    {
        if (culture != null)
        {
            var requestculture = new RequestCulture(culture, culture);
            var cookieName = CookieRequestCultureProvider.DefaultCookieName;
            var cookieValue = CookieRequestCultureProvider.MakeCookieValue(requestculture);

            HttpContext.Response.Cookies.Append(cookieName, cookieValue);
        }
        return LocalRedirect(redirectUri);
    }
}
