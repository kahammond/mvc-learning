using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Microsoft.AspNetCore.Mvc;
using TemplateAssignment.Models.PageTemplates;

[assembly: RegisterPageTemplate("Custom.ComplimentTemplate", "Compliment Template", typeof(ComplimentTemplateProperties), customViewName: "~/Views/Shared/PageTemplates/_Compliment.cshtml")]

namespace TemplateAssignment.Controllers
{
    public class ComplimentController : PageTemplateController<ComplimentTemplateProperties>
    {  
        public ActionResult CustomCompliment()
        {
            return new TemplateResult();
        }
    }
}
