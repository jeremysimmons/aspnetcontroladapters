using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using NUnit.Framework;
using ControlAdapters.Renderers;

namespace ControlAdapters.Tests
{
	[TestFixture]
	public class HtmlRendererTests
	{
		public class MockRenderer : HtmlRenderer<WebControl>
		{
			public override string RenderBeginTag()
			{
				throw new NotImplementedException();
			}
			public override string RenderContents()
			{
				throw new NotImplementedException();
			}
			public override string RenderEndTag()
			{
				throw new NotImplementedException();
			}
		}

		private WebControl control;
		private AttributeCollection attributes;

		[SetUp]
		public void SetUp()
		{
			control = new Label();
			attributes = new AttributeCollection(new StateBag());
		}

		[Test]
		public void SetsBackgroundColor()
		{
			control.BackColor = Color.Empty;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.IsNull(attributes.CssStyle["background-color"], "background-color improperly set when undefined");

			control.BackColor = Color.Blue;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.AreEqual(ColorTranslator.ToHtml(control.BackColor), attributes.CssStyle["background-color"], "background-color not set");
		}

		[Test]
		public void SetsBorderColor()
		{
			control.BorderColor = Color.Empty;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.IsNull(attributes.CssStyle["border-color"], "border-color improperly set when undefined");

			control.BorderColor = Color.Blue;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.AreEqual(ColorTranslator.ToHtml(control.BorderColor), attributes.CssStyle["border-color"], "border-color not set");
		}

		[Test]
		public void SetsBorderStyle()
		{
			control.BorderStyle = BorderStyle.NotSet;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.IsNull(attributes.CssStyle["border-style"], "border-style improperly set when undefined");

			control.BorderStyle = BorderStyle.Dotted;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.AreEqual(control.BorderStyle.ToString().ToLowerInvariant(), attributes.CssStyle["border-style"], "border-style not set");
		}

		[Test]
		public void SetsBorderWidth()
		{
			control.BorderWidth = Unit.Empty;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.IsNull(attributes.CssStyle["border-width"], "border-width improperly set when undefined");

			control.BorderWidth = new Unit(1.0, UnitType.Em);
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.AreEqual(control.BorderWidth.ToString(), attributes.CssStyle["border-width"], "border-width not set");
		}

		[Test]
		public void SetsColor()
		{
			control.ForeColor = Color.Empty;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.IsNull(attributes.CssStyle["color"], "color improperly set when undefined");

			control.ForeColor = Color.Black;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.AreEqual(ColorTranslator.ToHtml(control.ForeColor), attributes.CssStyle["color"], "color not set");
		}

		[Test]
		public void SetsHeight()
		{
			control.Height = Unit.Empty;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.IsNull(attributes.CssStyle["height"], "height improperly set when undefined");

			control.Height = new Unit(1.0, UnitType.Em);
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.AreEqual(control.Height.ToString(), attributes.CssStyle["height"], "height not set");
		}

		[Test]
		public void SetsWidth()
		{
			control.Width = Unit.Empty;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.IsNull(attributes.CssStyle["width"], "width improperly set when undefined");

			control.Width = new Unit(1.0, UnitType.Em);
			MockRenderer.AddDefautAttributesToCollection(control, attributes);
			Assert.AreEqual(control.Width.ToString(), attributes.CssStyle["width"], "width not set");
		}

		[Test]
		public void SetsCustomAttributes()
		{
			control.Attributes["someattrib"] = "somevalue";
			control.Attributes["someotherattrib"] = null;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);

			Assert.AreEqual("somevalue", attributes["someattrib"], "custom attribute with string value not set");
			Assert.IsNull(attributes["someotherattrib"], "custom attribute with null value improperly set");
		}

		[Test]
		public void WritesStylesProperly()
		{
			control.BackColor = Color.Black;
			control.ForeColor = Color.White;
			MockRenderer.AddDefautAttributesToCollection(control, attributes);

			HtmlTextWriter writer = new HtmlTextWriter(new System.IO.StringWriter());
			MockRenderer.WriteStyles(writer, attributes.CssStyle);

			Assert.AreEqual(" style=\"background-color:Black;color:White;\"", writer.InnerWriter.ToString());
		}

		[Test]
		public void WritesAttributesProperly()
		{
			control.BackColor = Color.Black;
			control.Attributes["someattrib"] = "somevalue";
			MockRenderer.AddDefautAttributesToCollection(control, attributes);

			HtmlTextWriter writer = new HtmlTextWriter(new System.IO.StringWriter());
			MockRenderer.WriteAttributes(writer, attributes);

			Assert.AreEqual(" style=\"background-color:Black;\" someattrib=\"somevalue\"", writer.InnerWriter.ToString());
		}
	}
}
