using CMS.DocumentEngine;
using Kentico.Content.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using Microsoft.AspNetCore.Mvc;
using NewSite.Models;
using NewSite.PageTemplates;
using System.Linq;

[assembly: RegisterPageTemplate("Keith.Goodbye", "Goodbye page", typeof(GoodbyePageProperties), customViewName: "~/Views/Shared/PageTemplates/_Goodbye.cshtml",
        Description = "Goodbye.", IconClass = "icon-l-text")]

namespace NewSite.Controllers
{
    public class GoodbyeController : PageTemplateController<GoodbyePageProperties>
    {
        // Contains an instance of the IPageTemplatePropertiesRetriever service (e.g., obtained via dependency injection)
        private readonly IPageTemplatePropertiesRetriever pageTemplatePropertiesRetriever;
        private readonly IPageDataContextInitializer pageDataContextInitializer;

        public GoodbyeController(IPageTemplatePropertiesRetriever pageTemplatePropertiesRetriever, IPageDataContextInitializer pageDataContextInitializer)
        {
            this.pageTemplatePropertiesRetriever = pageTemplatePropertiesRetriever;
            this.pageDataContextInitializer = pageDataContextInitializer;
        }

        public IActionResult Index(int documentId)
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
                return NotFound();
            }

            // Initializes the page builder with the DocumentID of the page
            pageDataContextInitializer.Initialize(documentId);

            // Gets the properties of the widget as a strongly typed object
            GoodbyePageProperties properties = pageTemplatePropertiesRetriever.Retrieve<GoodbyePageProperties>();

            var model = new GoodbyeViewModel()
            {
                ShowTitle = properties.ShowTitle,
                DocumentCulture = page.DocumentCulture,
                DocumentName = page.DocumentName
            };

            return PartialView("PageTemplates/_Goodbye", model);
        }
    }
}
