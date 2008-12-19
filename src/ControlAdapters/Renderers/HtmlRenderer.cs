using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlAdapters.Configuration;

namespace ControlAdapters.Renderers
{
	/// <summary>
	/// Provides custom HTML rendering for a <see cref="WebControl"/>.
	/// </summary>
	/// <typeparam name="T">A <see cref="WebControl"/> type.</typeparam>
	/// <remarks>
	/// Unlike typical controls related to rendering web markup, the HtmlRenderer does not
	/// output directly to the current request, even though an <see cref="HtmlTextWriter"/>
	/// is provided to many methods. Instead, this class is responsible for returning the HTML output
	/// as a string. 
	/// 
	/// This is done to improve testability. Output from HtmlRenderer objects
	/// can be tested programmatically, and the custom control adapters rely on these renderers
	/// for basic markup.
	/// </remarks>
	public abstract class HtmlRenderer<T> where T : WebControl
	{
		/// <summary>
		/// Represents the <see cref="ControlAdaptersConfiguration"/> settings for the current application instance.
		/// </summary>
		protected static ControlAdaptersConfigurationSection Settings = ControlAdaptersConfiguration.Settings;
		private T _control;
		
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		public HtmlRenderer()
		{
		}

		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="control">The control this renderer generates HTML for.</param>
		public HtmlRenderer(T control)
		{
			_control = control;
		}

		/// <summary>
		/// Gets or sets the control this renderer generates HTML for.
		/// </summary>
		public T Control
		{
			get { return _control; }
			set { _control = value; }
		}

		/// <summary>
		/// Renders the beginning HTML code for a control. Intended to be called by a control adapter's
		/// RenderBeginTag method.
		/// </summary>
		/// <returns>The generated HTML.</returns>
		public abstract string RenderBeginTag();

		/// <summary>
		/// Renders the inner HTML code for a control. Intended to be called by a control adapter's
		/// RenderContents method.
		/// </summary>
		/// <returns>The generated HTML.</returns>
		public abstract string RenderContents();

		/// <summary>
		/// Renders the ending HTML code for a control. Intended to be called by a control adapter's
		/// RenderEndTag method.
		/// </summary>
		/// <returns>The generated HTML.</returns>
		public abstract string RenderEndTag();

		/// <summary>
		/// Adds the default properties and attributes for a given control to a given attribute collection.
		/// </summary>
		/// <param name="control">The web control.</param>
		/// <param name="attributes">The collection of attributes.</param>
		/// <returns>The updated collection.</returns>
		public static AttributeCollection AddDefautAttributesToCollection(WebControl control, AttributeCollection attributes)
		{
			if (attributes == null)
				throw new ArgumentNullException("attributes");

			CssStyleCollection styles = attributes.CssStyle;

			if (control.BackColor != Color.Empty)
				styles["background-color"] = ColorTranslator.ToHtml(control.BackColor);
			if (control.BorderColor != Color.Empty)
				styles["border-color"] = ColorTranslator.ToHtml(control.BorderColor);
			if (control.BorderStyle != BorderStyle.NotSet)
				styles["border-style"] = control.BorderStyle.ToString().ToLowerInvariant();
			if (!control.BorderWidth.IsEmpty)
				styles["border-width"] = control.BorderWidth.ToString();
			if (control.ForeColor != Color.Empty)
				styles["color"] = ColorTranslator.ToHtml(control.ForeColor);
			if (!control.Height.IsEmpty)
				styles["height"] = control.Height.ToString();
			if (!control.Width.IsEmpty)
				styles["width"] = control.Width.ToString();

            foreach (string key in control.Attributes.Keys)
            {
                if (!String.Equals(key, "style", StringComparison.InvariantCultureIgnoreCase))
                    attributes.Add(key, control.Attributes[key]);
            }
			return attributes;
		}

		/// <summary>
		/// Writes a collection of attributes to the output stream.
		/// </summary>
		/// <param name="writer">The output stream to write to.</param>
		/// <param name="attributes">The collection of attributes.</param>
		public static void WriteAttributes(HtmlTextWriter writer, AttributeCollection attributes)
		{
			if (attributes.Count > 0)
			{
				foreach (string key in attributes.Keys)
				{
					writer.WriteAttribute(key, attributes[key]);
				}
			}
		}

		/// <summary>
		/// Writes a collection of styles to the output stream.
		/// </summary>
		/// <param name="writer">The output stream to write to.</param>
		/// <param name="styles">The collection of styles.</param>
		public static void WriteStyles(HtmlTextWriter writer, CssStyleCollection styles)
		{
			if (styles.Count > 0)
			{
				writer.Write(" style=\"");
				foreach (string key in styles.Keys)
				{
					writer.WriteStyleAttribute(key, styles[key], true);
				}
				writer.Write("\"");
			}
		}

		/// <summary>
		/// Concatenates a series of CSS class names into a markup-friendly class list.
		/// </summary>
		/// <param name="classes">The CSS classes to concatenate.</param>
		/// <returns>A markup-friendly class list.</returns>
		/// <remarks>
		/// Duplicates are permitted and would be included in the output. Empty strings are skipped.
		/// </remarks>
		public static string ConcatenateCssClasses(params string[] classes)
		{
			StringBuilder sb = new StringBuilder();
			foreach (string cl in classes)
			{
				if (String.IsNullOrEmpty(cl))
					continue;

				if (sb.Length > 0)
					sb.Append(' ');

				sb.Append(cl);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Gets the HTML Name attribute value, such as for form fields, from a given ID attribute value.
		/// </summary>
		/// <param name="clientID">The ID attribute value.</param>
		/// <returns>The corresponding Name attribute value.</returns>
		public static string GetNameFromClientID(string clientID)
		{
			return clientID.Replace('_', '$');
		}

		/// <summary>
		/// Gets an ASP.Net-formatted HTML ID for a given <see cref="ListItem"/> in a 
		/// given <see cref="ListControl"/>.
		/// </summary>
		/// <param name="control">The <see cref="ListControl"/> containing the list item.</param>
		/// <param name="item">The <see cref="ListItem"/> which the ClientID is generated for.</param>
		/// <returns>The HTML ID of the list item.</returns>
		/// <exception cref="ArgumentNullException">
		///	<paramref name="control"/> is null.
		/// </exception>
		/// <exception cref="IndexOutOfRangeException">
		/// <paramref name="item"/> does not exist in the Items collection for <paramref name="control"/>.
		/// </exception>
		public static string GetListItemClientID(ListControl control, ListItem item)
		{
			if (control == null)
				throw new ArgumentNullException("control");

			int index = GetListItemIndex(control, item);
			if (index == -1)
				throw new IndexOutOfRangeException(
					String.Format("ListItem '{0}' does not exist in ListControl '{1}'.", (item == null ? "null" : item.Text), control.ID));

			return String.Format("{0}_{1}", control.ClientID, index.ToString());
		}

		/// <summary>
		/// Gets the zero-based index of a given <see cref="ListItem"/> from a <see cref="ListControl"/>.
		/// </summary>
		/// <param name="control">The <see cref="ListControl"/> containing the list item.</param>
		/// <param name="item">The <see cref="ListItem"/> whose index is requested.</param>
		/// <returns>The index of the item. If the list item doesn't exist in the control, returns -1.</returns>
		/// <exception cref="ArgumentNullException">
		///	<paramref name="control"/> is null.
		/// </exception>
		public static int GetListItemIndex(ListControl control, ListItem item)
		{
			if (control == null)
				throw new ArgumentNullException("control");

			int index = control.Items.IndexOf(item);

			return index;
		}

		/// <summary>
		/// Returns a new <see cref="HtmlTextWriter"/> for use in rendering output.
		/// </summary>
		/// <returns>A new <see cref="HtmlTextWriter"/>.</returns>
		public static HtmlTextWriter CreateHtmlTextWriter()
		{
			return new HtmlTextWriter(new StringWriter());
		}
	}
}
