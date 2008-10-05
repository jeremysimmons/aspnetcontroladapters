using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlAdapters.Configuration;
using ControlAdapters.Renderers;

namespace ControlAdapters.Adapters
{
	public class CheckBoxListAdapter : ControlAdapterBase<CheckBoxList>
	{
		protected override HtmlRenderer<CheckBoxList> CreateHtmlRenderer()
		{
			return new CheckBoxListHtmlRenderer(this.AdaptedControl);
		}

		protected override void RenderBeginTag(HtmlTextWriter writer)
		{
			_renderer.RenderBeginTag(writer);
		}

		protected override void RenderContents(HtmlTextWriter writer)
		{
			_renderer.RenderContents(writer);
		}

		protected override void RenderEndTag(HtmlTextWriter writer)
		{
			_renderer.RenderEndTag(writer);
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
