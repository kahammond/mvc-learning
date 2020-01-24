using DancingGoat.Controllers.Widgets;
using DancingGoat.Models.Widgets.WeatherWidget;
using Kentico.PageBuilder.Web.Mvc;
using System.Web.Mvc;

[assembly: RegisterWidget("DancingGoat.Widgets.WeatherWidget", typeof(WeatherWidgetController), "Cafe city's weather", IconClass = "icon-cloud")]

namespace DancingGoat.Controllers.Widgets
{
    public class WeatherWidgetController : WidgetController<WeatherWidgetProperties>
    {
        // GET: WeatherWidget
        public ActionResult Index()
        {
            var properties = GetProperties();

            var model = new WeatherWidgetViewModel
            {
                DegreeUnit = properties.DegreeUnit,
                Cafe = properties.Cafe
            };

            return PartialView("Widgets/_WeatherWidget", model);
        }
    }
}
