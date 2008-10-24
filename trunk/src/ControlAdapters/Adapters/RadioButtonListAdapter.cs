using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlAdapters.Configuration;
using ControlAdapters.Renderers;

namespace ControlAdapters.Adapters
{
	/// <summary>
	/// Adapts the output of the <see cref="RadioButtonList"/> control.
	/// </summary>
	public class RadioButtonListAdapter : ControlAdapterBase<RadioButtonList>
	{
		/// <summary>
		/// Creates and returns the renderer to use for HTML rendering.
		/// </summary>
		/// <returns>The renderer to use.</returns>
		protected override HtmlRenderer<RadioButtonList> CreateHtmlRenderer()
		{
			return new RadioButtonListHtmlRenderer(this.AdaptedControl);
		}
	}
}
