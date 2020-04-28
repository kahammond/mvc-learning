using BlankSite.Controllers;
using BlankSite.Models.PageTemplates.LandingPage;
using CMS.DocumentEngine;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Kentico.Web.Mvc;
using System.Linq;
using System.Web.Mvc;

[assembly: RegisterPageTemplate("Keith.LandingPageTemplate", typeof(LandingPageController), "Default template with controller", IconClass = "icon-l-rows-2")]

namespace BlankSite.Controllers
{
    public class LandingPageController : PageTemplateController<LandingPageProperties>
    {
        // GET: LandingPage
        public ActionResult Display(int documentId)
        {

            // Retrieves the page from the Kentico database
            TreeNode page = DocumentHelper.GetDocuments()
                .WhereEquals("DocumentID", documentId)
                .OnCurrentSite()
                .TopN(1)
                .FirstOrDefault();

            // Returns a 404 error when the retrieving is unsuccessful
            if (page == null)
            {
                return HttpNotFound();
            }

            // Initializes the page builder with the DocumentID of the page
            HttpContext.Kentico().PageBuilder().Initialize(page.DocumentID);

            LandingPageProperties properties = GetProperties();

            var model = new LandingPageViewModel()
            {
                ShowTitle = properties.ShowTitle,
                DocumentName = page.DocumentName
            };

            // Returns a TemplateResult object, created with an identifier of the page as its parameter
            // Automatically initializes the page builder feature for any editable areas placed within templates
            return PartialView("PageTemplates/_LandingPageTemplate", model);
        }
    }
}
