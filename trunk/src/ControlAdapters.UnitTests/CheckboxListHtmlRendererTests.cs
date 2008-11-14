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
		private HtmlTextWriter writer;
		private CheckBoxList control;
		private ListItem listItem;
		private CheckBoxListHtmlRenderer renderer;

		[SetUp]
		public void SetUp()
		{
			writer = new HtmlTextWriter(new StringWriter());
			control = new CheckBoxList();
			control.ID = "checkbox";
			listItem = new ListItem();
			control.Items.Add(listItem);
			renderer = new CheckBoxListHtmlRenderer(control);
		}

		[Test]
		public void RendersRequiredCheckBoxAttributes()
		{
			renderer.RenderCheckBoxListInput(writer, listItem, CheckBoxListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.AreEqual("<input id=\"checkbox_0\" name=\"checkbox$0\" type=\"checkbox\" />", writer.InnerWriter.ToString(),
				"checkbox required attributes not rendered properly");
		}

		[Test]
		public void RendersValue()
		{
			listItem.Value = "test";
			renderer.RenderCheckBoxListInput(writer, listItem, CheckBoxListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("value=\"test\""), "list item value not rendered");
		}

		[Test]
		public void RendersDisabled()
		{
			listItem.Enabled = false;
			renderer.RenderCheckBoxListInput(writer, listItem, CheckBoxListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("disabled=\"disabled\""), "disabled attribute not rendered");
		}

		[Test]
		public void RendersChecked()
		{
			listItem.Selected = true;
			renderer.RenderCheckBoxListInput(writer, listItem, CheckBoxListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("checked=\"checked\""), "checked attribute not rendered");
		}

		[Test]
		public void RendersAccessKey()
		{
			control.AccessKey = "C";
			renderer.RenderCheckBoxListInput(writer, listItem, CheckBoxListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("accesskey=\"C\""), "accesskey attribute not rendered");
		}

		[Test]
		public void RendersTabIndex()
		{
			control.TabIndex = 4;
			renderer.RenderCheckBoxListInput(writer, listItem, CheckBoxListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("tabindex=\"4\""), "tabindex attribute not rendered");
		}

		[Test]
		public void RendersPostBackHandler()
		{
			control.AutoPostBack = true;
			renderer.RenderCheckBoxListInput(writer, listItem, CheckBoxListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("onclick=\"javascript:setTimeout('__doPostBack(\\'checkbox$0\\',\\'\\')', 0)\""), "postback handler not rendered");
		}

		[Test]
		public void RendersLabelWithText()
		{
			listItem.Text = "text";
			listItem.Value = "value";
			renderer.RenderCheckBoxListLabel(writer, listItem, CheckBoxListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.AreEqual("<label for=\"checkbox_0\">text</label>", writer.InnerWriter.ToString(), "label not rendered properly");
		}

		[Test]
		public void RendersLabelWithValue()
		{
			listItem.Text = String.Empty;
			listItem.Value = "value";
			renderer.RenderCheckBoxListLabel(writer, listItem, CheckBoxListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.AreEqual("<label for=\"checkbox_0\">value</label>", writer.InnerWriter.ToString(), "label not rendered properly");
		}

		[Test]
		public void RendersNoLabelWhenTextAndValueAreEmpty()
		{
			listItem.Text = String.Empty;
			listItem.Value = String.Empty;
			renderer.RenderCheckBoxListLabel(writer, listItem, CheckBoxListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.AreEqual(String.Empty, writer.InnerWriter.ToString(), "label not rendered properly");
		}
	}
}
