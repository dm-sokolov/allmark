using AllMark.DTO;
using Kendo.Mvc.UI.Fluent;

namespace Utils.Kendo.Extensions
{
    public static class DropDownTreeExtensions
    {
        public static DropDownTreeBuilder BaseDropDownTree(this DropDownTreeBuilder builder)
        {
            return builder.DataTextField(nameof(CategoryDto.Name))
                        .DataValueField(nameof(CategoryDto.Id))
                        .AutoWidth(true);
        }

        public static DropDownTreeBuilder CategoryDropDownTree(this DropDownTreeBuilder builder)
        {
            return builder.Placeholder("Категория 'по умолчанию'")
                          .DataSource(i => i.Read(read => read.Action("GetCategories", "Product"))
                                .Model(model => model.Id(nameof(CategoryDto.CategoryId))
                                                     .HasChildren(nameof(CategoryDto.HasChildren))
                                )
                            );
        }
    }
}
