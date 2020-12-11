using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

namespace NewSite.PageTemplates
{
    public class GoodbyePageProperties : IPageTemplateProperties
    {
        // Defines a property and sets its default value
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 0, Label = "Show title")]
        public bool ShowTitle { get; set; } = true;
    }
}
