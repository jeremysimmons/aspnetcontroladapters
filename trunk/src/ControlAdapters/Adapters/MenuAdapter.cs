using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlAdapters.Configuration;
using ControlAdapters.Renderers;

namespace ControlAdapters.Adapters
{
	/// <summary>
	/// Adapts the output of the <see cref="Menu"/> control.
	/// </summary>
	public class MenuAdapter : ControlAdapterBase<Menu>
	{
		/// <summary>
		/// Creates and returns the renderer to use for HTML rendering.
		/// </summary>
		/// <returns>The renderer to use.</returns>
		protected override HtmlRenderer<Menu> CreateHtmlRenderer()
		{
			return new MenuHtmlRenderer(this.AdaptedControl);
		}
	}
}
