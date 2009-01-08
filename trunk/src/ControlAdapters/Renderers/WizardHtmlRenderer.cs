﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlAdapters.Configuration;

namespace ControlAdapters.Renderers
{
	/// <summary>
	/// Renders a <see cref="Wizard"/> using HTML markup.
	/// </summary>
	public class WizardHtmlRenderer : HtmlRenderer<Wizard>
	{
		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		/// <param name="control">The <see cref="Wizard"/> control that this class will render.</param>
		public WizardHtmlRenderer(Wizard control)
			: base(control)
		{
		}

		/// <summary>
		/// Renders the beginning tag that wraps around the rendered HTML.
		/// </summary>
		/// <returns>The beginning tag HTML code.</returns>
		public override string RenderBeginTag()
        {
            HtmlTextWriter writer = CreateHtmlTextWriter();
            AttributeCollection attributes = new AttributeCollection(new StateBag(true));

            string cssClass = Settings.Wizard.CssClass;
            string disabledCssClass = Settings.CheckBoxList.DisabledCssClass;

            string allClasses = ConcatenateCssClasses(
                cssClass,
                (Control.Enabled ? String.Empty : disabledCssClass),
                Control.CssClass);

            writer.WriteBeginTag("div");

            attributes.Add("id", Control.ClientID);
            if (!String.IsNullOrEmpty(allClasses))
                attributes.Add("class", allClasses);
            if (Control.TabIndex > 0)
                attributes.Add("tabindex", Control.TabIndex.ToString());

            AddDefautAttributesToCollection(Control, attributes);
            WriteAttributes(writer, attributes);

            writer.WriteLine(HtmlTextWriter.TagRightChar);

            return writer.InnerWriter.ToString();
		}

		/// <summary>
		/// Renders inner HTML code representing the adapted control.
		/// </summary>
		/// <returns>The inner HTML code representing the adapted control.</returns>
		public override string RenderContents()
		{
            HtmlTextWriter writer = CreateHtmlTextWriter();

            writer.WriteBeginTag("div");
            string headerClass = ControlAdaptersConfiguration.Settings.Wizard.HeaderCssClass;
            if (!String.IsNullOrEmpty(headerClass))
                writer.WriteAttribute("class", headerClass);
            writer.Write(HtmlTextWriter.TagRightChar);

            String headerContents = RenderWizardHeader();
            writer.Write(headerContents);

            writer.WriteEndTag("div");

            return writer.InnerWriter.ToString();
		}

        /// <summary>
        /// Renders the header for the wizard.
        /// </summary>
        /// <returns></returns>
        protected string RenderWizardHeader()
        {
            if (this.Control.HeaderTemplate != null)
                return GenerateHtmlFromTemplate(this.Control.HeaderTemplate);
            else
                return this.Control.HeaderText;
        }

		/// <summary>
		/// Renders the ending tag that closes the tag generated by <see cref="RenderBeginTag"/>.
		/// </summary>
		/// <returns>The ending tag HTML code.</returns>
		public override string RenderEndTag()
        {
            HtmlTextWriter writer = CreateHtmlTextWriter();

            writer.Indent--;
            writer.WriteEndTag("div");
            writer.WriteLine();

            return writer.InnerWriter.ToString();
		}
	}
}
