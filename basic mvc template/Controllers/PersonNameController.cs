using CMS.DocumentEngine;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using System.Linq;
using System.Web.Mvc;

namespace BlankSite.Controllers
{
    public class PersonNameController : Controller
    {
        // GET: PersonName
        public ActionResult Display(int nodeId)
        {
            // Retrieves the page from the Kentico database
            TreeNode page = DocumentHelper.GetDocuments()
                .WhereEquals("NodeID", nodeId)
                .Culture("en-US")
                .OnCurrentSite()
                .TopN(1)
                .FirstOrDefault();

            // Returns a 404 error when the retrieving is unsuccessful
            if (page == null)
            {
                return HttpNotFound();
            }

            // Returns a TemplateResult object, created with an identifier of the page as its parameter
            // Automatically initializes the page builder feature for any editable areas placed within templates
            return new TemplateResult(page.DocumentID);
        }
    }
}
