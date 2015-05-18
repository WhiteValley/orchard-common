using System;
using Orchard.Autoroute.Models;
using Orchard.ContentManagement;
using Orchard.Localization;
using Orchard.Projections.Descriptors.Filter;
using Orchard.Projections.Services;


namespace WhiteValley.Common.Filters
{
    public class AutorouteFilter : IFilterProvider
    {

        public Localizer T { get; set; }



        public AutorouteFilter()
        {
            T = NullLocalizer.Instance;
        }
        

        public void Describe(DescribeFilterContext describe)
        {
            describe.For("Autoroute", T("Autoroute"), T("The ID of the area"))
                .Element("Permalink", T("Permalink"), T("The URL for the content"),
                    ApplyFilter,
                    DisplayFilter,
                    "AutorouteFilter"
                );

        }


        public void ApplyFilter(FilterContext context)
        {
            var path = (string)context.State.Path;
            if (String.IsNullOrEmpty(path))
                return;

            context.Query = context.Query.Where(alias => alias.ContentPartRecord<AutoroutePartRecord>(), expr => expr.Like("DisplayAlias", path, HqlMatchMode.Start));
        }


        public LocalizedString DisplayFilter(FilterContext context)
        {
            string url = context.State.Path;
            return String.IsNullOrEmpty(url) ? T("Starts with URL") : T("Starts with URL {0}", url);
        }

    }

}
