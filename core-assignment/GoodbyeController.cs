using CMS.DocumentEngine.Types.Custom;
using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using TemplateAssignment.Controllers;
using TemplateAssignment.Models;

[assembly: RegisterPageRoute(Goodbye.CLASS_NAME, typeof(GoodbyeController), ActionName = "CustomGoodbye")]

namespace TemplateAssignment.Controllers
{
    public class GoodbyeController : Controller
    {
        private readonly IPageDataContextRetriever dataRetriever;

        public GoodbyeController(IPageDataContextRetriever dataRetriever)
        {
            // Initializes an instance of a service that provides data context of pages matching the requested URL
            this.dataRetriever = dataRetriever;
        }

        public ActionResult CustomGoodbye()
        {
            var goodbye = dataRetriever.Retrieve<Goodbye>().Page;
            var model = GetGoodbyeViewModel(goodbye.GoodbyeFarewell);

            return View(model);
        }

        private GoodbyeViewModel GetGoodbyeViewModel(string goodByeMessage)
        {
            return new GoodbyeViewModel
            {
                GoodbyeFarewell = goodByeMessage
            };
        }
    }
}
