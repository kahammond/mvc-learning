using CMS.DataEngine;
using CMS.DocumentEngine;

namespace DancingGoat.Models.Widgets.WeatherWidget
{
    public class WeatherWidgetViewModel
    {
        public string DegreeUnit { get; set; }

        public string Cafe { get; set; }

        public string Location { get; set; }

        public string ZipCode { get; set; }

        public int Temperature { get; set; }

        public string ErrorMessage { get; set; }
    }
}
