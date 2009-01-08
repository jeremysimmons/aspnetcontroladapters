﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlAdapters.Renderers
{
	/// <summary>
	/// Renders a <see cref="Menu"/> using HTML markup.
	/// </summary>
	public class MenuHtmlRenderer : HtmlRenderer<Menu>
	{
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="control">The <see cref="Menu"/> control that this class will render.</param>
		public MenuHtmlRenderer(Menu control)
			: base(control)
		{
		}

		/// <summary>
		/// Renders the beginning tag that wraps around the rendered HTML.
		/// </summary>
		/// <returns>The beginning tag HTML code.</returns>
		public override string RenderBeginTag()
		{
			HtmlTextWriter writer = CreateHtmlTextWriter();
			AttributeCollection attributes = new AttributeCollection(new StateBag(true));

			string cssClass = Settings.Menu.CssClass;
			string disabledCssClass = Settings.CheckBoxList.DisabledCssClass;

			string allClasses = ConcatenateCssClasses(
				cssClass,
				(Control.Enabled ? String.Empty : disabledCssClass),
				Control.Orientation.ToString().ToLowerInvariant(),
				Control.CssClass);

			writer.WriteBeginTag("ul");

			attributes.Add("id", Control.ClientID);
			if (!String.IsNullOrEmpty(allClasses))
				attributes.Add("class", allClasses);
			if (Control.TabIndex > 0)
				attributes.Add("tabindex", Control.TabIndex.ToString());

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

			foreach (MenuItem item in Control.Items)
			{
				RenderMenuItem(writer, item, 1);
			}

			return writer.InnerWriter.ToString();
		}

        /// <summary>
        /// Renders a menu item. Is used recursively to handle child menu items.
        /// </summary>
        /// <param name="writer">The <see cref="HtmlTextWriter"/> to use to generate HTML.</param>
        /// <param name="item">The menu item to render.</param>
        /// <param name="level">The level of this menu item (hierarchical level).</param>
		protected void RenderMenuItem(HtmlTextWriter writer, MenuItem item, int level)
		{
			bool enabled = (item.Enabled && Control.Enabled);
			string cssClass = (enabled ? String.Empty : Settings.Menu.DisabledCssClass);

			writer.Write("\t");
			writer.WriteBeginTag("li");
			if (!String.IsNullOrEmpty(cssClass))
				writer.WriteAttribute("class", cssClass);
			writer.Write(HtmlTextWriter.TagRightChar);

			AttributeCollection attributes = new AttributeCollection(new StateBag(true));
			writer.WriteBeginTag("a");
			
			if (!String.IsNullOrEmpty(item.ToolTip))
				attributes.Add("title", item.ToolTip);
			if (enabled && item.Selectable && Control.Page != null)
			{
				string href = this.Control.Page.ClientScript.GetPostBackClientHyperlink(Control, item.Value);
				attributes.Add("href", href);
			}
			WriteAttributes(writer, attributes);
			writer.Write(HtmlTextWriter.TagRightChar);
			writer.Write((String.IsNullOrEmpty(item.Text) ? item.Value : item.Text));

			writer.WriteEndTag("a");

			if (item.ChildItems != null && item.ChildItems.Count > 0 && level < (Control.StaticDisplayLevels + Control.MaximumDynamicDisplayLevels))
			{
				writer.WriteBeginTag("ul");
				if (level >= Control.StaticDisplayLevels)
					writer.WriteAttribute("class", "dynamic");
				writer.Write(HtmlTextWriter.TagRightChar);
				writer.WriteLine();
				writer.Indent++;

				foreach (MenuItem innerItem in item.ChildItems)
					RenderMenuItem(writer, innerItem, level + 1);

				writer.Indent--;
				writer.WriteEndTag("ul");
				writer.WriteLine();
			}

			writer.WriteEndTag("li");
			writer.WriteLine();
		}

		/// <summary>
		/// Renders the ending tag that closes the tag generated by <see cref="RenderBeginTag"/>.
		/// </summary>
		/// <returns>The ending tag HTML code.</returns>
		public override string RenderEndTag()
		{
			HtmlTextWriter writer = CreateHtmlTextWriter();

			writer.Indent--;
			writer.WriteEndTag("ul");
			writer.WriteLine();

			return writer.InnerWriter.ToString();
		}
	}
}
