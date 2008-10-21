using System;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using ControlAdapters.Configuration;
using ControlAdapters.Renderers;

namespace ControlAdapters.Adapters
{
	/// <summary>
	/// Provides an abstract base class for our custom control adapters.
	/// </summary>
	/// <typeparam name="T">A type of <see cref="WebControl"/> that this adapter will service.</typeparam>
	public abstract class ControlAdapterBase<T> : WebControlAdapter where T : WebControl
	{
		/// <summary>
		/// Gets or sets the <see cref="HtmlRenderer"/> used by this adapter.
		/// </summary>
		public HtmlRenderer<T> HtmlRenderer { get; set; }

		/// <summary>
		/// Returns a strongly-typed instance of the <see cref="WebControlAdapter.Control"/> property.
		/// </summary>
		public T AdaptedControl
		{
			get { return this.Control as T; }
		}

		/// <summary>
		/// Abstract class that returns the appropriate <see cref="HtmlRenderer"/> to use for this class.
		/// </summary>
		/// <returns>An <see cref="HtmlRenderer"/>.</returns>
		protected abstract HtmlRenderer<T> CreateHtmlRenderer();

		/// <summary>
		/// Initializes the control adapter prior to rendering markup.
		/// The default implementation creates the <see cref="HtmlRenderer"/> to use by the 
		/// adapter by calling <see cref="CreateHtmlRenderer"/> if the renderer has not
		/// already been provided.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override void OnPreRender(EventArgs e)
		{
			if (HtmlRenderer == null)
				HtmlRenderer = CreateHtmlRenderer();

			base.OnPreRender(e);
		}

		/// <summary>
		/// Writes the beginning HTML tag to the output stream.
		/// The default implementation writes the HtmlRenderer's RenderBeginTag
		/// output to the output stream.
		/// </summary>
		/// <param name="writer">The output stream.</param>
		protected override void RenderBeginTag(HtmlTextWriter writer)
		{
			writer.Write(HtmlRenderer.RenderBeginTag());
		}

		/// <summary>
		/// Writes the HTML contents to the output stream.
		/// The default implementation writes the HtmlRenderer's RenderContents
		/// output to the output stream.
		/// </summary>
		/// <param name="writer">The output stream.</param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			writer.Write(HtmlRenderer.RenderContents());
		}

		/// <summary>
		/// Writes the beginning HTML tag to the output stream.
		/// The default implementation writes the HtmlRenderer's RenderEndTag
		/// output to the output stream.
		/// </summary>
		/// <param name="writer">The output stream.</param>
		protected override void RenderEndTag(HtmlTextWriter writer)
		{
			writer.Write(HtmlRenderer.RenderEndTag());
		}
	}
}
