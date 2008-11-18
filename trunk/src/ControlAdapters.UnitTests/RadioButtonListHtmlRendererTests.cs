using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using NUnit.Framework;
using ControlAdapters.Renderers;

namespace ControlAdapters.UnitTests
{
	[TestFixture]
	public class RadioButtonListHtmlRendererTests
	{
		private HtmlTextWriter writer;
		private RadioButtonList control;
		private ListItem listItem;
		private RadioButtonListHtmlRenderer renderer;

		[SetUp]
		public void SetUp()
		{
			writer = new HtmlTextWriter(new StringWriter());
			control = new RadioButtonList();
			control.ID = "radiobutton";
			control.CssClass = "someclass";
			control.RepeatDirection = RepeatDirection.Horizontal;
			listItem = new ListItem();
			control.Items.Add(listItem);
			renderer = new RadioButtonListHtmlRenderer(control);
		}

		[Test]
		public void RendersBeginTag()
		{
			Assert.That(renderer.RenderBeginTag().StartsWith("<" + renderer.OuterTag),
				"Outer tag not being properly used");
		}

		[Test]
		public void RendersEndTag()
		{
			Assert.AreEqual("</" + renderer.OuterTag + ">\r\n", renderer.RenderEndTag(), "Inner tag not being properly rendered");
		}

		[Test]
		public void RendersBeginTagID()
		{
			Assert.That(renderer.RenderBeginTag().Contains(" id=\"radiobutton\""), "ID attribute not included in begin tag");
		}

		[Test]
		public void RendersBeginTagClasses()
		{
			Assert.That(renderer.RenderBeginTag().Contains(" class=\"radioButtonList horizontal someclass\""), "CSS classes not included in begin tag");
		}

		[Test]
		public void RendersTableLayoutListItem()
		{
			control.RepeatLayout = RepeatLayout.Table;

			Assert.That(renderer.RenderContents().StartsWith("\t<li>"), "LI tag not used in Table layout");
		}

		[Test]
		public void RendersFlowLayoutSpanWithCssClass()
		{
			control.RepeatLayout = RepeatLayout.Flow;
			control.Enabled = false;
			Assert.That(renderer.RenderContents().StartsWith("\t<span class=\"disabled\">"),
				"span tag not used in Flow layout with CSS class");
		}

		[Test]
		public void RendersLabelBeforeInputWhenAlignedLeft()
		{
			listItem.Value = "value";
			control.TextAlign = TextAlign.Left;
			string output = renderer.RenderContents();

			Assert.That(output.IndexOf("<label") < output.IndexOf("<input"), "Label not before input when TextAlign = Left");
		}

		[Test]
		public void RendersLabelAfterInputWhenAlignedRight()
		{
			listItem.Value = "value";
			control.TextAlign = TextAlign.Right;
			string output = renderer.RenderContents();

			Assert.That(output.IndexOf("<input") < output.IndexOf("<label"), "Label not after input when TextAlign = Right");
		}

		[Test]
		public void RendersRequiredRadioButtonAttributes()
		{
			renderer.RenderRadioButtonListInput(writer, listItem, RadioButtonListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.AreEqual("<input id=\"radiobutton_0\" name=\"radiobutton\" type=\"radio\" />", writer.InnerWriter.ToString(),
				"radio button required attributes not rendered properly");
		}

		[Test]
		public void RendersValue()
		{
			listItem.Value = "test";
			renderer.RenderRadioButtonListInput(writer, listItem, RadioButtonListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("value=\"test\""), "list item value not rendered");
		}

		[Test]
		public void RendersDisabled()
		{
			listItem.Enabled = false;
			renderer.RenderRadioButtonListInput(writer, listItem, RadioButtonListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("disabled=\"disabled\""), "disabled attribute not rendered");
		}

		[Test]
		public void RendersChecked()
		{
			listItem.Selected = true;
			renderer.RenderRadioButtonListInput(writer, listItem, RadioButtonListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("checked=\"checked\""), "checked attribute not rendered");
		}

		[Test]
		public void RendersAccessKey()
		{
			control.AccessKey = "C";
			renderer.RenderRadioButtonListInput(writer, listItem, RadioButtonListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("accesskey=\"C\""), "accesskey attribute not rendered");
		}

		[Test]
		public void RendersTabIndex()
		{
			control.TabIndex = 4;
			renderer.RenderRadioButtonListInput(writer, listItem, RadioButtonListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("tabindex=\"4\""), "tabindex attribute not rendered");
		}

		[Test]
		public void RendersPostBackHandler()
		{
			control.AutoPostBack = true;
			renderer.RenderRadioButtonListInput(writer, listItem, RadioButtonListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.IsTrue(writer.InnerWriter.ToString().Contains("onclick=\"javascript:setTimeout('__doPostBack(\\'radiobutton$0\\',\\'\\')', 0)\""), "postback handler not rendered");
		}

		[Test]
		public void RendersLabelWithText()
		{
			listItem.Text = "text";
			listItem.Value = "value";
			renderer.RenderRadioButtonListLabel(writer, listItem, RadioButtonListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.AreEqual("<label for=\"radiobutton_0\">text</label>", writer.InnerWriter.ToString(), "label not rendered properly");
		}

		[Test]
		public void RendersLabelWithValue()
		{
			listItem.Text = String.Empty;
			listItem.Value = "value";
			renderer.RenderRadioButtonListLabel(writer, listItem, RadioButtonListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.AreEqual("<label for=\"radiobutton_0\">value</label>", writer.InnerWriter.ToString(), "label not rendered properly");
		}

		[Test]
		public void RendersNoLabelWhenTextAndValueAreEmpty()
		{
			listItem.Text = String.Empty;
			listItem.Value = String.Empty;
			renderer.RenderRadioButtonListLabel(writer, listItem, RadioButtonListHtmlRenderer.GetListItemClientID(control, listItem));

			Assert.AreEqual(String.Empty, writer.InnerWriter.ToString(), "label not rendered properly");
		}

		[Test]
		public void UsesProperOuterTag()
		{
			control.RepeatLayout = RepeatLayout.Table;
			Assert.AreEqual("ul", renderer.OuterTag, "RepeatLayout.Table not properly using 'ul' outer tag");

			control.RepeatLayout = RepeatLayout.Flow;
			Assert.AreEqual("span", renderer.OuterTag, "RepeatLayout.Table not properly using 'span' outer tag");
		}
	}
}
