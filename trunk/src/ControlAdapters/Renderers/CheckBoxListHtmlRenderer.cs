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

		public override string RenderBeginTag(HtmlTextWriter writer)
		{
			string cssClass = Settings.CheckBoxList.CssClass;
			string disabledCssClass = Settings.CheckBoxList.DisabledCssClass;
			string repeatDirectionCssClass = Settings.CheckBoxList.RepeatDirectionCssClass;

			if (!String.IsNullOrEmpty(repeatDirectionCssClass))
				repeatDirectionCssClass += Control.RepeatDirection.ToString();

			string allClasses = ConcatenateCssClasses(cssClass, repeatDirectionCssClass,
				(Control.Enabled ? String.Empty : disabledCssClass), Control.CssClass);

			// UL
			if (!String.IsNullOrEmpty(allClasses))
				writer.AddAttribute(HtmlTextWriterAttribute.Class, allClasses);
			writer.AddAttribute(HtmlTextWriterAttribute.Id, Control.ClientID);
			writer.RenderBeginTag(HtmlTextWriterTag.Ul);
			writer.Indent++;

			return writer.InnerWriter.ToString();
		}

		public override void RenderContents(HtmlTextWriter writer)
		{
			foreach (ListItem li in Control.Items)
			{
				string itemClientID = GetListItemClientID(Control, li);

				// LI
				string cssClass = ConcatenateCssClasses(
					Settings.CheckBoxList.ItemCssClass, 
					(li.Enabled && Control.Enabled ? String.Empty : Settings.CheckBoxList.DisabledCssClass));
				if (!String.IsNullOrEmpty(cssClass))
					writer.AddAttribute(HtmlTextWriterAttribute.Class, cssClass);
				writer.RenderBeginTag(HtmlTextWriterTag.Li);
				/*
				if (checkList.TextAlign == TextAlign.Right)
				{
					RenderCheckBoxListInput(writer, checkList, li);
					RenderCheckBoxListLabel(writer, checkList, li);
				}
				else // TextAlign.Left
				{
					RenderCheckBoxListLabel(writer, checkList, li);
					RenderCheckBoxListInput(writer, checkList, li);
				}
				*/
				writer.RenderEndTag(); // LI
				writer.WriteLine();
			}
		}

		public override void RenderEndTag(HtmlTextWriter writer)
		{
			writer.Indent--;
			writer.RenderEndTag(); // UL
		}
	}
}
