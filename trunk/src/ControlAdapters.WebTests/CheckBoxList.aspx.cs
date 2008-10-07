using System;
using ControlAdapters.Renderers;

namespace ControlAdapters.WebTests
{
	public partial class CheckBoxList : System.Web.UI.Page
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			CheckBoxListHtmlRenderer renderer = new CheckBoxListHtmlRenderer(CheckBoxList2);

			adaptedMarkup.InnerHtml = Server.HtmlEncode(renderer.RenderBeginTag() + renderer.RenderContents() + renderer.RenderEndTag());
		}
	}
}
