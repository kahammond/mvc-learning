using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Microsoft.AspNetCore.Mvc;

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
