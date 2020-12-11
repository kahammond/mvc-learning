using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Microsoft.AspNetCore.Mvc;
using NewSite.PageTemplates;

[assembly: RegisterPageTemplate("Keith.Hello", "Hello page", typeof(HelloPageProperties), customViewName: "~/Views/Shared/PageTemplates/_Hello.cshtml",
        Description = "Hello.", IconClass = "icon-l-text")]

namespace NewSite.Controllers
{
    public class HelloController : Controller
    {
        public IActionResult Index(int documentId)
        {
            // Returns a TemplateResult object, created with an identifier of the page as its parameter
            // Automatically initializes the page builder feature for any editable areas placed within templates
            return new TemplateResult(documentId);
        }
    }
}
