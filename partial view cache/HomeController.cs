using System.Linq;
using System.Web.Mvc;

using CMS.DocumentEngine.Types.DancingGoatMvc;
using DancingGoat.Infrastructure;
using DancingGoat.Models.Home;
using DancingGoat.Repositories;

using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;

namespace DancingGoat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository mHomeRepository;
        private readonly IOutputCacheDependencies mOutputCacheDependencies;


        public HomeController(IHomeRepository homeRepository,
                              IOutputCacheDependencies outputCacheDependencies)
        {
            mHomeRepository = homeRepository;
            mOutputCacheDependencies = outputCacheDependencies;
        }


        // GET: Home
        // [OutputCache(CacheProfile = "PageBuilder")]
        public ActionResult Index()
        {
            var home = mHomeRepository.GetHomePage();
            if (home == null)
            {
                return HttpNotFound();
            }

            HttpContext.Kentico().PageBuilder().Initialize(home.DocumentID);

            var viewModel = new IndexViewModel
            {
                HomeSections = mHomeRepository.GetHomeSections().Select(HomeSectionViewModel.GetViewModel)
            };
            
            mOutputCacheDependencies.AddDependencyOnPage<Home>(home.DocumentID);
            mOutputCacheDependencies.AddDependencyOnPages<HomeSection>();

            return View(viewModel);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 10)]
        public PartialViewResult PartialViewCacheChild()
        {
            return PartialView("_PartialViewForCache");
        }
    }
}
