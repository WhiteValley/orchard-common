using System;
using Orchard.DisplayManagement;
using Orchard.Forms.Services;
using Orchard.Localization;


namespace WhiteValley.Common.Filters
{

    public class AutorouteFilterForm : IFormProvider
    {
        protected dynamic Shape { get; set; }
        public Localizer T { get; set; }


        public AutorouteFilterForm(IShapeFactory shapeFactory)
        {
            Shape = shapeFactory;
            T = NullLocalizer.Instance;
        }


        public void Describe(DescribeContext context)
        {
            Func<IShapeFactory, object> form =
                shape =>
                {
                    var s = Shape.Form(
                        Id: "StartsWithPath",
                          _Parts: Shape.Textbox(
                            Id: "path",
                            Name: "Path",
                            Title: T("Path"),
                            Description: T("Enter the path that the URL must start with")
                            )
                        );
                    return s;
                };
            context.Form("AutorouteFilter", form);
        }

    }

}