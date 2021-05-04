using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;

namespace TemplateAssignment.Models.PageTemplates
{
    public class ComplimentTemplateProperties : IPageTemplateProperties
    {
        // Defines a property and sets its default value
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 0, Label = "Show title")]
        public bool ShowCompliment { get; set; } = true;

        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 1, Label = "Thank you message")]
        public string ThankYouMessage { get; set; } = "Thank you for letting us compliment you.";
    }
}
