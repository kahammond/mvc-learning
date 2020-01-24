using DancingGoat.Models.FormComponents.CafeLocationSelector;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace DancingGoat.Models.Widgets.WeatherWidget
{

    public class WeatherWidgetProperties : IWidgetProperties
    {

        public const string explanationText = "Select the Unit to display the temperature.";
        public const string label = "Temperature Unit";
        //public const string tooltip = "Select a temperature unit.";

        [EditingComponent(RadioButtonsComponent.IDENTIFIER, Order = 0, ExplanationText = explanationText, Label = label)]
        [EditingComponentProperty(nameof(RadioButtonsProperties.DataSource), "F;Fahrenheit\r\nC;Celsius\r\nK;Kelvin")]
        public string DegreeUnit { get; set; }

        [EditingComponent(CafeCityDropDownComponent.IDENTIFIER, Order = 1, Label = "Cafe")]
        public string Cafe { get; set; }
    }
}
