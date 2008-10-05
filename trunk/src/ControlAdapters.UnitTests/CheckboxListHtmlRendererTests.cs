using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using NUnit.Framework;
using ControlAdapters.Renderers;

namespace ControlAdapters.UnitTests
{
	[TestFixture]
	public class CheckboxListHtmlRendererTests
	{
		private StringWriter stringwriter;
		private HtmlTextWriter htmlwriter;

		[SetUp]
		public void SetUp()
		{
			stringwriter = new StringWriter();
			htmlwriter = new HtmlTextWriter(stringwriter);
		}

		[Test]
		public void TestValidHtml()
		{
			CheckBoxList control = new CheckBoxList();
			control.ID = "test";
			CheckBoxListHtmlRenderer renderer = new CheckBoxListHtmlRenderer(control);

			Assert.AreEqual(renderer.RenderBeginTag(htmlwriter), 
				"<ul class=\"AspNet-CheckBoxList AspNet-CheckBoxList-RepeatDirection-Vertical\" id=\"test\">\r\n");
		}
	}
}
