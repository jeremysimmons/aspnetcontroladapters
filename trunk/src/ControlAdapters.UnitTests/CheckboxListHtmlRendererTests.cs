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
			control.Items.Add(new ListItem("item1", "value1"));
			CheckBoxListHtmlRenderer renderer = new CheckBoxListHtmlRenderer(control);

			Assert.AreEqual(renderer.RenderBeginTag(),
				"<ul class=\"checkBoxList vertical\" id=\"test\">\r\n");

			Assert.AreEqual(renderer.RenderContents(),
				"\t<li><input id=\"test_0\" name=\"test$0\" type=\"checkbox\" value=\"value1\" /><label for=\"test_0\">item1</label></li>\r\n");

			Assert.AreEqual(renderer.RenderEndTag(),
				"</ul>\r\n");
		}
	}
}
