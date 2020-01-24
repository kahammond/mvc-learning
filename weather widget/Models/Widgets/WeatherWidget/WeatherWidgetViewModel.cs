using CMS.DataEngine;
using CMS.DocumentEngine;

namespace DancingGoat.Models.Widgets.WeatherWidget
{
    public class WeatherWidgetViewModel
    {
        public string DegreeUnit { get; set; }

        public string Cafe { get; set; }

        public string Location {
            get
            {
                string location = "It failed if you see this";

                DocumentQuery cafes = DocumentHelper.GetDocuments("DancingGoatMvc.Cafe")
                                    .Path("/Cafes/", PathTypeEnum.Children)
                                    .OnSite("DancingGoatMvc")
                                    .Culture("en-us")
                                    .Where("DocumentName", QueryOperator.Equals, Cafe)
                                    .TopN(1);
                
                foreach (TreeNode cafe in cafes)
                {
                    location = cafe.GetValue<string>("CafeCountry", "Location not available");
                }

                return location;
            }

            set
            {

            }
        }
    }
}
