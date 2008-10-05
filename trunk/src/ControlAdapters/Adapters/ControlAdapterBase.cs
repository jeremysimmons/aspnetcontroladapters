using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Adapters;
using ControlAdapters.Configuration;
using ControlAdapters.Renderers;

namespace ControlAdapters.Adapters
{
	public abstract class ControlAdapterBase<T> : WebControlAdapter where T : WebControl
	{
		protected HtmlRenderer<T> _renderer;

		public HtmlRenderer<T> HtmlRenderer
		{
			set { _renderer = value; }
		}

		public T AdaptedControl
		{
			get { return this.Control as T; }
		}

		protected abstract HtmlRenderer<T> CreateHtmlRenderer();

		protected override void OnPreRender(EventArgs e)
		{
			_renderer = CreateHtmlRenderer();
		}

		protected override void RenderBeginTag(HtmlTextWriter writer)
		{
			writer.Write(_renderer.RenderBeginTag(writer));
		}

		protected override void RenderContents(HtmlTextWriter writer)
		{
			_renderer.RenderContents(writer);
		}

		protected override void RenderEndTag(HtmlTextWriter writer)
		{
			_renderer.RenderEndTag(writer);
		}
	}
}
