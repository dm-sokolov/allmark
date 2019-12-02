using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Utils.NationalCatalog.Models;
using Utils.Kendo.Extensions;
using Kendo.Mvc.UI;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using System.IO;
using System.Web;

namespace AllMark.HtmlHelpers
{
    public static class AttributeHtmlHelper
    {
        public static HtmlString CreateAttributeControls<T>(this IHtmlHelper<IEnumerable<T>> helper, CatalogAttribute attribute)
        {
            var parentDiv = new TagBuilder("div");
            
            if (attribute.ValueTypes?.Any() ?? false)
            {
                if (attribute.FieldType == "number")
                {
                    var textBoxDiv = new TagBuilder("div");
                    var textBox = helper.Kendo()
                                        .NumericTextBox()
                                        .Name($"tbAttr{attribute.Id}")
                                        .FullWidth();
                    textBoxDiv.InnerHtml.Append(textBox.Deferred().ToHtmlString());
                    var comboBoxDiv = new TagBuilder("div");
                    var comboBox = helper.Kendo()
                                         .ComboBox()
                                         .Name($"cbAttrValueType{attribute.Id}")
                                         .Items(i =>
                                         {
                                             foreach (var presetItem in attribute.Preset)
                                             {
                                                 i.Add()
                                                     .Text(presetItem)
                                                     .Value(presetItem);
                                             }
                                         })
                                         .FullWidth();
                    comboBoxDiv.InnerHtml.Append(comboBox.Deferred().ToHtmlString());
                    parentDiv.InnerHtml.AppendHtml(textBoxDiv);
                    parentDiv.InnerHtml.AppendHtml(comboBoxDiv);
                }
                else
                {
                    if (attribute.Preset?.Any() ?? false)
                    {
                        if (attribute.Preset.Count < 3 && attribute.Preset.Contains("НЕ ОПРЕДЕЛЕНО"))
                        {
                            var attrValueDiv = new TagBuilder("div");
                            var combobox = helper.Kendo()
                                            .ComboBox()
                                            .Name($"cbAttr{attribute.Id}")
                                            .Items(i =>
                                            {
                                                foreach (var presetItem in attribute.Preset)
                                                {
                                                    i.Add()
                                                     .Text(presetItem)
                                                     .Value(presetItem);
                                                }
                                            })
                                            .FullWidth();
                            attrValueDiv.InnerHtml.Append(combobox.Deferred().ToHtmlString());
                            var attrValueTypeDiv = new TagBuilder("div");
                            var typeCombobox = helper.Kendo()
                                            .ComboBox()
                                            .Name($"cbAttrValueType{attribute.Id}")
                                            .Items(i =>
                                            {
                                                foreach (var presetItem in attribute.ValueTypes)
                                                {
                                                    i.Add()
                                                     .Text(presetItem)
                                                     .Value(presetItem);
                                                }
                                                i.Add()
                                                 .Text("ДРУГОЕ")
                                                 .Value("ДРУГОЕ");
                                            })
                                            .FullWidth();
                            attrValueTypeDiv.InnerHtml.Append(typeCombobox.Deferred().ToHtmlString());
                            var hiddenTextBoxDiv = new TagBuilder("div");
                            var hiddentTextBox = helper.Kendo()
                                                       .TextBox()
                                                       .Name($"tbAttr{attribute.Id}")
                                                       .FullWidth();
                            hiddenTextBoxDiv.InnerHtml.Append(hiddentTextBox.Deferred().ToHtmlString());
                            parentDiv.InnerHtml.AppendHtml(attrValueDiv);
                            parentDiv.InnerHtml.AppendHtml(attrValueTypeDiv);
                            parentDiv.InnerHtml.AppendHtml(hiddenTextBoxDiv);
                        }
                        else
                        {
                            var attrValueDiv = new TagBuilder("div");
                            var combobox = helper.Kendo()
                                            .ComboBox()
                                            .Name($"cbAttr{attribute.Id}")
                                            .Items(i =>
                                            {
                                                foreach (var presetItem in attribute.Preset)
                                                {
                                                    i.Add()
                                                     .Text(presetItem)
                                                     .Value(presetItem);
                                                }
                                            })
                                            .FullWidth();
                            attrValueDiv.InnerHtml.Append(combobox.Deferred().ToHtmlString());
                            var attrValueTypeDiv = new TagBuilder("div");
                            var typeCombobox = helper.Kendo()
                                            .ComboBox()
                                            .Name($"cbAttrValueType{attribute.Id}")
                                            .Items(i =>
                                            {
                                                foreach (var presetItem in attribute.ValueTypes)
                                                {
                                                    i.Add()
                                                     .Text(presetItem)
                                                     .Value(presetItem);
                                                }
                                                i.Add()
                                                 .Text("ДРУГОЕ")
                                                 .Value("ДРУГОЕ");
                                            })
                                            .FullWidth();
                            attrValueTypeDiv.InnerHtml.Append(typeCombobox.Deferred().ToHtmlString());
                            parentDiv.InnerHtml.AppendHtml(attrValueDiv);
                            parentDiv.InnerHtml.AppendHtml(attrValueTypeDiv);
                        }
                    }
                    else
                    {
                        var textBoxDiv = new TagBuilder("div");
                        var textBox = helper.Kendo()
                                            .TextBox()
                                            .Name($"tbAttr{attribute.Id}")
                                            .FullWidth();
                        textBoxDiv.InnerHtml.Append(textBox.Deferred().ToHtmlString());
                        var comboBoxDiv = new TagBuilder("div");
                        var comboBox = helper.Kendo()
                                             .ComboBox()
                                             .Name($"cbAttrValueType{attribute.Id}")
                                             .Items(i =>
                                             {
                                                 foreach (var presetItem in attribute.ValueTypes)
                                                 {
                                                     i.Add()
                                                         .Text(presetItem)
                                                         .Value(presetItem);
                                                 }
                                             })
                                             .FullWidth();
                        comboBoxDiv.InnerHtml.Append(comboBox.Deferred().ToHtmlString());
                        parentDiv.InnerHtml.AppendHtml(textBoxDiv);
                        parentDiv.InnerHtml.AppendHtml(comboBoxDiv);
                    }
                }
            }
            else
            {
                if (attribute.FieldType == "number")
                {
                    var numericTextBox = helper.Kendo()
                                               .IntegerTextBox()
                                               .Name($"tbAttr{attribute.Id}")
                                               .FullWidth();
                    parentDiv.InnerHtml.Append(numericTextBox.Deferred().ToHtmlString());
                }
                else
                {
                    if (attribute.Preset?.Any() ?? false)
                    {
                        var combobox = helper.Kendo()
                                            .ComboBox()
                                            .Name($"cbAttr{attribute.Id}")
                                            .Items(i =>
                                            {
                                                foreach (var presetItem in attribute.Preset)
                                                {
                                                    i.Add()
                                                     .Text(presetItem)
                                                     .Value(presetItem);
                                                }
                                            })
                                            .FullWidth();
                        parentDiv.InnerHtml.Append(combobox.Deferred().ToHtmlString());
                    }
                    else
                    {
                        var textBox = helper.Kendo()
                                              .TextBox()
                                              .Name($"tbAttr{attribute.Id}")
                                              .FullWidth();
                        parentDiv.InnerHtml.Append(textBox.Deferred().ToHtmlString());
                    }
                }
            }
            var writer = new StringWriter();
            parentDiv.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(HttpUtility.HtmlDecode(writer.ToString()));
        }
    }
}
