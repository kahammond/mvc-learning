using Kentico.PageBuilder.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc.PageTemplates;
using TemplateAssignment.Models.PageTemplates;

//Sections
[assembly: RegisterSection("TemplateAssignment.Sections.SampleSection", "Sample section", null, "../Views/Components/Sections/_SampleSection.cshtml")]

//Page Templates
[assembly: RegisterPageTemplate("CompanyName.MyTemplate", "My template", typeof(InsultTemplateProperties), "PageTemplates/_Insult")]
