using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlAdapters.Configuration;

namespace ControlAdapters.Renderers
{
	public class RadioButtonListHtmlRenderer : HtmlRenderer<RadioButtonList>
	{
		public RadioButtonListHtmlRenderer(RadioButtonList control)
			: base(control)
		{
		}

		private string OuterTag
		{
			get { return Control.RepeatLayout == RepeatLayout.Table ? "ul" : "span"; }
		}

		public override string RenderBeginTag()
		{
			HtmlTextWriter writer = GetNewHtmlTextWriter();

			string cssClass = Settings.RadioButtonList.CssClass;
			string disabledCssClass = Settings.RadioButtonList.DisabledCssClass;
			string repeatDirectionCssClass = Control.RepeatDirection.ToString().ToLowerInvariant();

			string allClasses = ConcatenateCssClasses(cssClass, repeatDirectionCssClass,
				(Control.Enabled ? String.Empty : disabledCssClass), Control.CssClass);

			writer.WriteBeginTag(this.OuterTag);
			writer.WriteAttribute("id", Control.ClientID);

			if (!String.IsNullOrEmpty(allClasses))
				writer.WriteAttribute("class", allClasses);

			foreach (string key in Control.Attributes.Keys)
				writer.WriteAttribute(key, Control.Attributes[key]);
			
			WriteStyles(writer);
			writer.WriteLine(HtmlTextWriter.TagRightChar);

			return writer.InnerWriter.ToString();
		}

		public override string RenderContents()
		{
			HtmlTextWriter writer = GetNewHtmlTextWriter();

			foreach (ListItem li in Control.Items)
			{
				string inputID = GetListItemClientID(Control, li);
				string cssClass = (li.Enabled && Control.Enabled ? String.Empty : Settings.RadioButtonList.DisabledCssClass);

				writer.Write("\t");

				if (Control.RepeatLayout == RepeatLayout.Table)
				{
					writer.WriteBeginTag("li");
					if (!String.IsNullOrEmpty(cssClass))
						writer.WriteAttribute("class", cssClass);
					writer.Write(HtmlTextWriter.TagRightChar);
				}
				else if (!String.IsNullOrEmpty(cssClass))
				{
					writer.WriteBeginTag("span");
					writer.WriteAttribute("class", cssClass);
					writer.Write(HtmlTextWriter.TagRightChar);
				}

				if (Control.TextAlign == TextAlign.Right)
				{
					RenderRadioButtonListInput(writer, li, inputID);
					RenderRadioButtonListLabel(writer, li, inputID);
				}
				else // TextAlign.Left
				{
					RenderRadioButtonListLabel(writer, li, inputID);
					RenderRadioButtonListInput(writer, li, inputID);
				}

				if (Control.RepeatLayout == RepeatLayout.Table)
					writer.WriteEndTag("li");
				else if (Control.RepeatDirection == RepeatDirection.Vertical)
					writer.Write("<br />");

				writer.WriteLine();
			}

			return writer.InnerWriter.ToString();
		}

		protected void RenderRadioButtonListLabel(HtmlTextWriter writer, ListItem li, string inputID)
		{
			if (String.IsNullOrEmpty(li.Text) && String.IsNullOrEmpty(li.Value))
				return;

			writer.WriteBeginTag("label");
			writer.WriteAttribute("for", inputID);
			writer.Write(HtmlTextWriter.TagRightChar);
			writer.Write(String.IsNullOrEmpty(li.Text) ? li.Value : li.Text);
			writer.WriteEndTag("label");
		}

		protected void RenderRadioButtonListInput(HtmlTextWriter writer, ListItem li, string inputID)
		{
			string inputName = GetNameFromClientID(Control.ClientID);
			writer.WriteBeginTag("input");
			writer.WriteAttribute("id", inputID);
			writer.WriteAttribute("name", inputName);
			writer.WriteAttribute("type", "radio");
			
			if (!String.IsNullOrEmpty(li.Value))
				writer.WriteAttribute("value", li.Value);
			if (li.Enabled == false)
				writer.WriteAttribute("disabled", "disabled");
			if (li.Selected == true)
				writer.WriteAttribute("checked", "checked");
			if (!String.IsNullOrEmpty(Control.AccessKey))
				writer.WriteAttribute("accesskey", Control.AccessKey);
			if (Control.TabIndex != -1)
				writer.WriteAttribute("tabindex", Control.TabIndex.ToString());
			if (Control.AutoPostBack)
				writer.WriteAttribute("onclick", String.Format(@"javascript:setTimeout('__doPostBack(\'{0}\',\'\')', 0)", inputName));

			writer.Write(HtmlTextWriter.SelfClosingTagEnd);
		}

		public override string RenderEndTag()
		{
			HtmlTextWriter writer = GetNewHtmlTextWriter();

			writer.Indent--;
			writer.WriteEndTag(this.OuterTag);
			writer.WriteLine();

			return writer.InnerWriter.ToString();
		}
	}
}
