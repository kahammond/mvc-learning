using CMS.DocumentEngine;
using DancingGoat.Models.FormComponents.CafeLocationSelector;
using Kentico.Forms.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

[assembly: RegisterFormComponent(CafeCityDropDownComponent.IDENTIFIER, typeof(CafeCityDropDownComponent), "Drop-down with Cafe City data", IconClass = "icon-menu")]

namespace DancingGoat.Models.FormComponents.CafeLocationSelector
{
    public class CafeCityDropDownComponent : SelectorFormComponent<CafeCityDropDownProperties>
    {
        public const string IDENTIFIER = "CafeCityDropDownComponent";

        // Retrieves data to be displayed in the selector
        protected override IEnumerable<SelectListItem> GetItems()
        {
            // Perform data retrieval operations here
            // The following example retrieves all pages of the 'DancingGoatMvc.Article' page type
            // located under the 'Cafes' section of the Dancing Goat sample website
            DocumentQuery cafes = DocumentHelper.GetDocuments("DancingGoatMvc.Cafe")
                                .Path("/Cafes/", PathTypeEnum.Children)
                                .Columns("DocumentName", "DocumentGUID")
                                .OnSite("DancingGoatMvc")
                                .Culture("en-us")
                                .LatestVersion();

            var sampleData = cafes.TypedResult.Select(x => new
            {
                Name = x.DocumentName
            });

            //Iterates over retrieved data and transforms it into SelectListItems
            foreach (var cafe in sampleData)
            {
                var listItem = new SelectListItem()
                {
                    Value = cafe.Name,
                    Text = cafe.Name
                };

                yield return listItem;
            }
        }
    }
}
