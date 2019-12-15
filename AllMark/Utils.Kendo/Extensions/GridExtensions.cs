using Kendo.Mvc.UI;
using Kendo.Mvc.UI.Fluent;

namespace Utils.Kendo.Extensions
{
    public static class GridExtensions
    {
        public static GridBuilder<T> BaseGrid<T>(this GridBuilder<T> grid) where T : class
        {
            return grid.ColumnMenu(m => m.Enabled(true)
                       .Sortable(true))
                       .Sortable()
                       .Resizable(r => r.Columns(true))
                       .Selectable(s => s.Enabled(false))
                       .Pageable(p => p.PageSizes(new int[]
                       {
                            10, 20, 50, 100, 200, 500, 1000
                       })
                       .Refresh(true)
                       .Messages(m =>
                       {
                           m.Display("{0} - {1} из {2} элементов");
                           m.ItemsPerPage("элементов на странице");
                           m.Empty("Нет элементов для отображения");
                       }))
                       .Scrollable()
                       .Groupable(g => g.Enabled(true)
                       .ShowFooter(true))
                       .Selectable(s => s.Mode(GridSelectionMode.Single)
                                         .Type(GridSelectionType.Row))
                       .HtmlAttributes(new { style = "height: 100%; widht: 100%;" });
        }
    }
}
