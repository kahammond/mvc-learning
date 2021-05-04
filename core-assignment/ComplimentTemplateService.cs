using CMS.Core;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using System.Linq;

namespace TemplateAssignment.PageTemplates
{
    public class ComplimentTemplateService
    {
        // Initializes an instance of a service used for page retrieval
        private readonly IPageRetriever pageRetriever;

        public ComplimentTemplateService(IPageRetriever pageRetriever)
        {
            this.pageRetriever = pageRetriever;
        }

        public string GetLatestInsult()
        {
            TreeNode page = pageRetriever.Retrieve<Insult>(query => query
                                .TopN(1))
                                .FirstOrDefault();

            return page.DocumentName;
        }
    }
}
