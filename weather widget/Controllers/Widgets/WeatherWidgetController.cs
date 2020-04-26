using CMS.DataEngine;
using CMS.DocumentEngine;
using DancingGoat.Controllers.Widgets;
using DancingGoat.Models.Widgets.WeatherWidget;
using Kentico.PageBuilder.Web.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web.Mvc;

[assembly: RegisterWidget("DancingGoat.Widgets.WeatherWidget", typeof(WeatherWidgetController), "Cafe city's weather", IconClass = "icon-cloud")]

namespace DancingGoat.Controllers.Widgets
{
    public class WeatherWidgetController : WidgetController<WeatherWidgetProperties>
    {
        //Current temperature will only be accurate for USA cities.
        const string API_URL = "http://api.openweathermap.org/data/2.5/weather?zip={0}&units={1}&APPID=b7463a8754f42bd3026b18a31aa0687a";

        // GET: WeatherWidget
        public ActionResult Index()
        {
            WeatherWidgetProperties properties = GetProperties();

            string location = "Error retrieving location.";
            string zipCode = "Error retrieving zip code.";
            string format;

            //Queries for the cafe that matches the selected Cafe property value.
            DocumentQuery cafes = DocumentHelper.GetDocuments("DancingGoatMvc.Cafe")
                                .Path("/Cafes/", PathTypeEnum.Children)
                                .OnSite("DancingGoatMvc")
                                .Culture("en-us")
                                .Where("DocumentName", QueryOperator.Equals, properties.Cafe)
                                .TopN(1);

            //Pulls city, state, country, and zip code values from query result.
            //Preps Zip Code for weather API call.
            foreach (TreeNode cafe in cafes)
            {
                string city = cafe.GetValue<string>("CafeCity", "City not available");
                string country = cafe.GetValue<string>("CafeCountry", "Country not available");
                zipCode = cafe.GetValue<string>("CafeZipCode", "Zip code not available");

                //Location value varies if in the USA or not.
                if (country.Contains("USA"))
                {
                    string state = country.Substring(4);
                    location = city + ", " + state + ", USA";
                }
                else
                {
                    location = city + ", " + country;
                }

            }

            //Prepares property DegreeUnit for API call.
            switch (properties.DegreeUnit)
            {
                case "F":
                    format = "imperial";
                    break;
                case "C":
                    format = "metric";
                    break;
                case "K":
                    format = "default";
                    break;
                default:
                    format = "imperial";
                    break;
            }



            //Constructs part of the View Model
            var model = new WeatherWidgetViewModel
            {
                DegreeUnit = properties.DegreeUnit,
                Cafe = properties.Cafe,
                Location = location,
                ZipCode = zipCode
            };

            try
            {
                string json;

                using (WebClient wc = new WebClient())
                {
                    json = wc.DownloadString(String.Format(API_URL, zipCode, format));
                }

                var data = JsonConvert.DeserializeObject<WeatherResponse>(json);

                model.Temperature = (int)Math.Round(data.main.temp);
            }
            catch (Exception ex)
            {
                model.ErrorMessage = "Could not load weather data! Did you enter a valid city name? Details:<br/>" + ex.Message;
            }

            return PartialView("Widgets/_WeatherWidget", model);
        }
    }
}
