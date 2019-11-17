using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;

namespace Utils.Kendo.Extensions
{
    public static class WidgetBuilderBaseExtensions
    {
        public static WidgetBuilderBase<TViewComponent, TBuilder> FullWidth<TViewComponent, TBuilder>(this WidgetBuilderBase<TViewComponent, TBuilder> builder)
            where TViewComponent : WidgetBase
            where TBuilder : WidgetBuilderBase<TViewComponent, TBuilder> => builder.HtmlAttributes(new { style = "width: 100%;" });
    }
}
