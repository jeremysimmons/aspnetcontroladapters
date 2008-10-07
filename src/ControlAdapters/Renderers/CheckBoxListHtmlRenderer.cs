using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlAdapters.Configuration;

namespace ControlAdapters.Renderers
{
	public class CheckBoxListHtmlRenderer : HtmlRenderer<CheckBoxList>
	{
		public CheckBoxListHtmlRenderer(CheckBoxList control)
			: base(control)
		{
		}

		public override string RenderBeginTag()
		{
			HtmlTextWriter writer = GetNewHtmlTextWriter();

			string cssClass = Settings.CheckBoxList.CssClass;
			string disabledCssClass = Settings.CheckBoxList.DisabledCssClass;
			string repeatDirectionCssClass = Settings.CheckBoxList.RepeatDirectionCssClass;

			if (!String.IsNullOrEmpty(repeatDirectionCssClass))
				repeatDirectionCssClass += Control.RepeatDirection.ToString();

			string allClasses = ConcatenateCssClasses(cssClass, repeatDirectionCssClass,
				(Control.Enabled ? String.Empty : disabledCssClass), Control.CssClass);

			writer.WriteBeginTag("ul");
			if (!String.IsNullOrEmpty(allClasses))
				writer.WriteAttribute("class", allClasses);
			writer.WriteAttribute("id", Control.ClientID);
			writer.WriteLine(HtmlTextWriter.TagRightChar);

			return writer.InnerWriter.ToString();
		}

		public override string RenderContents()
		{
			HtmlTextWriter writer = GetNewHtmlTextWriter();

			foreach (ListItem li in Control.Items)
			{
				string inputID = GetListItemClientID(Control, li);
				string cssClass = ConcatenateCssClasses(
					Settings.CheckBoxList.ItemCssClass, 
					(li.Enabled && Control.Enabled ? String.Empty : Settings.CheckBoxList.DisabledCssClass));

				writer.Write("\t");
				writer.WriteBeginTag("li");
				if (!String.IsNullOrEmpty(cssClass))
					writer.WriteAttribute("class", cssClass);
				writer.Write(HtmlTextWriter.TagRightChar);
	
				if (Control.TextAlign == TextAlign.Right)
				{
					RenderCheckBoxListInput(writer, li, inputID);
					RenderCheckBoxListLabel(writer, li, inputID);
				}
				else // TextAlign.Left
				{
					RenderCheckBoxListLabel(writer, li, inputID);
					RenderCheckBoxListInput(writer, li, inputID);
				}

				writer.WriteEndTag("li");
				writer.WriteLine();
			}

			return writer.InnerWriter.ToString();
		}

		protected void RenderCheckBoxListLabel(HtmlTextWriter writer, ListItem li, string inputID)
		{
			if (String.IsNullOrEmpty(li.Text) && String.IsNullOrEmpty(li.Value))
				return;

			writer.WriteBeginTag("label");
			writer.WriteAttribute("for", inputID);
			writer.Write(HtmlTextWriter.TagRightChar);
			writer.Write(String.IsNullOrEmpty(li.Text) ? li.Value : li.Text);
			writer.WriteEndTag("label");
		}

		protected void RenderCheckBoxListInput(HtmlTextWriter writer, ListItem li, string inputID)
		{
			writer.WriteBeginTag("input");
			writer.WriteAttribute("id", inputID);
			writer.WriteAttribute("name", GetNameFromClientID(inputID));
			writer.WriteAttribute("type", "checkbox");
			if (li.Enabled == false)
				writer.WriteAttribute("disabled", "disabled");
			writer.WriteAttribute("value", li.Value);
			writer.Write(HtmlTextWriter.SelfClosingTagEnd);
		}

		public override string RenderEndTag()
		{
			HtmlTextWriter writer = GetNewHtmlTextWriter();

			writer.Indent--;
			writer.WriteEndTag("ul");
			writer.WriteLine();

			return writer.InnerWriter.ToString();
		}
	}
}
