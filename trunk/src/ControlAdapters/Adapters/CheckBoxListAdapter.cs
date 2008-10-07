using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlAdapters.Configuration;
using ControlAdapters.Renderers;

namespace ControlAdapters.Adapters
{
	/// <summary>
	/// Adapts the output of the <see cref="CheckBoxList"/> control.
	/// </summary>
	public class CheckBoxListAdapter : ControlAdapterBase<CheckBoxList>
	{
		/// <summary>
		/// Creates and returns the renderer to use for HTML rendering.
		/// </summary>
		/// <returns>The renderer to use.</returns>
		protected override HtmlRenderer<CheckBoxList> CreateHtmlRenderer()
		{
			return new CheckBoxListHtmlRenderer(this.AdaptedControl);
		}

		protected override void EndRender(HtmlTextWriter writer)
		{
			foreach (ListItem li in AdaptedControl.Items)
			{
				/*
				if (this.Page != null)
				{
					Page.ClientScript.RegisterForEventValidation(checkList.UniqueID, li.Value);
				}
				 * */
			}
			/*
			if (this.Page != null)
			{
				Page.ClientScript.RegisterForEventValidation(checkList.UniqueID);
			}
			 * */
		}
	}
}
