using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlAdapters.Configuration;

namespace ControlAdapters.Renderers
{
	/// <summary>
	/// Renders a <see cref="CheckBoxList"/> using HTML markup.
	/// </summary>
	public class CheckBoxListHtmlRenderer : HtmlRenderer<CheckBoxList>
	{
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="control">The <see cref="CheckBoxList"/> control that this class will render.</param>
		public CheckBoxListHtmlRenderer(CheckBoxList control)
			: base(control)
		{
		}

		/// <summary>
		/// Gets the appropriate outer tag name, based on the control's <see cref="RepeatLayout"/> property.
		/// </summary>
		public string OuterTag
		{
			get { return Control.RepeatLayout == RepeatLayout.Table ? "ul" : "span"; }
		}

		/// <summary>
		/// Renders the beginning tag that wraps around the rendered HTML.
		/// This method uses the <see cref="OuterTag"/> property to determine the tag name.
		/// </summary>
		/// <returns>The beginning tag HTML code.</returns>
		public override string RenderBeginTag()
		{
			HtmlTextWriter writer = CreateHtmlTextWriter();
			AttributeCollection attributes = new AttributeCollection(new StateBag(true));

			string cssClass = Settings.CheckBoxList.CssClass;
			string disabledCssClass = Settings.CheckBoxList.DisabledCssClass;
			string repeatDirectionCssClass = Control.RepeatDirection.ToString().ToLowerInvariant();

			string allClasses = ConcatenateCssClasses(cssClass, repeatDirectionCssClass,
				(Control.Enabled ? String.Empty : disabledCssClass), Control.CssClass);

			writer.WriteBeginTag(this.OuterTag);

			attributes.Add("id", Control.ClientID);
			if (!String.IsNullOrEmpty(allClasses))
				attributes.Add("class", allClasses);

			AddDefautAttributesToCollection(Control, attributes);
			WriteAttributes(writer, attributes);

			writer.WriteLine(HtmlTextWriter.TagRightChar);

			return writer.InnerWriter.ToString();
		}

		/// <summary>
		/// Renders inner HTML code representing the adapted control.
		/// </summary>
		/// <returns>The inner HTML code representing the adapted control.</returns>
		public override string RenderContents()
		{
			HtmlTextWriter writer = CreateHtmlTextWriter();

			foreach (ListItem li in Control.Items)
			{
				string inputID = GetListItemClientID(Control, li);
				string cssClass = (li.Enabled && Control.Enabled ? String.Empty : Settings.CheckBoxList.DisabledCssClass);

				writer.Write("\t");

				switch (Control.RepeatLayout)
				{
					case RepeatLayout.Table:
						writer.WriteBeginTag("li");
						if (!String.IsNullOrEmpty(cssClass))
							writer.WriteAttribute("class", cssClass);
						writer.Write(HtmlTextWriter.TagRightChar);
						break;

					case RepeatLayout.Flow:
						if (!String.IsNullOrEmpty(cssClass))
						{
							writer.WriteBeginTag("span");
							writer.WriteAttribute("class", cssClass);
							writer.Write(HtmlTextWriter.TagRightChar);
						}
						break;

					default:
						throw new NotImplementedException("Unknown RepeatLayout found: " + Control.RepeatLayout);
				}

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

				if (Control.RepeatLayout == RepeatLayout.Table)
					writer.WriteEndTag("li");
				else if (Control.RepeatDirection == RepeatDirection.Vertical)
					writer.Write("<br />");

				writer.WriteLine();
			}

			return writer.InnerWriter.ToString();
		}

		/// <summary>
		/// Renders the HTML for the input control's label.
		/// </summary>
		/// <param name="writer">The <see cref="HtmlTextWriter"/> to use to generate HTML.</param>
		/// <param name="li">The <see cref="ListItem"/> representing the input control this label is for.</param>
		/// <param name="inputID">The HTML ID of the input control this label is for.</param>
		public void RenderCheckBoxListLabel(HtmlTextWriter writer, ListItem li, string inputID)
		{
			if (String.IsNullOrEmpty(li.Text) && String.IsNullOrEmpty(li.Value))
				return;

			writer.WriteBeginTag("label");
			writer.WriteAttribute("for", inputID);
			writer.Write(HtmlTextWriter.TagRightChar);
			writer.Write(String.IsNullOrEmpty(li.Text) ? li.Value : li.Text);
			writer.WriteEndTag("label");
		}

		/// <summary>
		/// Renders the HTML for the check box input control.
		/// </summary>
		/// <param name="writer">The <see cref="HtmlTextWriter"/> to use to generate HTML.</param>
		/// <param name="li">The <see cref="ListItem"/> representing the input control.</param>
		/// <param name="inputID">The HTML ID of the input control.</param>
		public void RenderCheckBoxListInput(HtmlTextWriter writer, ListItem li, string inputID)
		{
			string inputName = GetNameFromClientID(inputID);
			writer.WriteBeginTag("input");
			writer.WriteAttribute("id", inputID);
			writer.WriteAttribute("name", inputName);
			writer.WriteAttribute("type", "checkbox");
			
			if (!String.IsNullOrEmpty(li.Value))
				writer.WriteAttribute("value", li.Value);
			if (li.Enabled == false)
				writer.WriteAttribute("disabled", "disabled");
			if (li.Selected == true)
				writer.WriteAttribute("checked", "checked");
			if (!String.IsNullOrEmpty(Control.AccessKey))
				writer.WriteAttribute("accesskey", Control.AccessKey);
			if (Control.TabIndex != 0)
				writer.WriteAttribute("tabindex", Control.TabIndex.ToString());
			if (Control.AutoPostBack)
				writer.WriteAttribute("onclick", String.Format(@"javascript:setTimeout('__doPostBack(\'{0}\',\'\')', 0)", inputName));

			writer.Write(HtmlTextWriter.SelfClosingTagEnd);
		}

		/// <summary>
		/// Renders the ending tag that closes the tag generated by <see cref="RenderBeginTag"/>.
		/// This method uses the <see cref="OuterTag"/> property to determine the tag name.
		/// </summary>
		/// <returns>The ending tag HTML code.</returns>
		public override string RenderEndTag()
		{
			HtmlTextWriter writer = CreateHtmlTextWriter();

			writer.Indent--;
			writer.WriteEndTag(this.OuterTag);
			writer.WriteLine();

			return writer.InnerWriter.ToString();
		}
	}
}
