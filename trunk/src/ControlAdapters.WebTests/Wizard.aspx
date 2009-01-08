<%@ Page Language="C#" AutoEventWireup="false" %>
<%@ Import Namespace="ControlAdapters.Renderers" %>

<script runat="server">
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		if (!useTemplates.Checked)
		{
			defaultWizard.HeaderTemplate = null;
			adaptedWizard.HeaderTemplate = null;
		}

		WizardHtmlRenderer renderer = new WizardHtmlRenderer(adaptedWizard);
		adaptedMarkup.InnerHtml = Server.HtmlEncode(renderer.RenderBeginTag() + renderer.RenderContents() + renderer.RenderEndTag());
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head id="Head1" runat="server">
		<title>Control Adapters: Wizard</title>
	</head>
	<body>
		<form id="form1" runat="server">
			<div>
				<h1>ControlAdapters Wizard Adapter Tests</h1>

				<h2>Markup Options</h2>
				
				<asp:CheckBox runat="server" ID="useTemplates" Checked="true" Text="Use Header Template?" AutoPostBack="true" />
				<asp:Button ID="Button1" runat="server" Text="Update" />
				
				<hr />

				<h2>Default ASP.Net Markup</h2>
				
				<asp:Wizard ID="defaultWizard" runat="server" 
					BackColor="Gray" BorderColor="Red" BorderStyle="Dashed" BorderWidth="2px" 
					ForeColor="White" Height="400px" Width="400px" 
					AccessKey="A" CssClass="wizard-class" style="margin:0 auto;"
					HeaderText="Header Text"
					>
					<HeaderTemplate>
						<h3>Templated Wizard - Header</h3>
					</HeaderTemplate>
					<WizardSteps>
						<asp:WizardStep ID="step1">
							<p>Step 1</p>
						</asp:WizardStep>
					</WizardSteps>
				</asp:Wizard>
					
				<hr />

				<h2>Adapted ASP.Net Markup</h2>

				<ca:Wizard ID="adaptedWizard" runat="server" 
					BackColor="Gray" BorderColor="Red" BorderStyle="Dashed" BorderWidth="2px" 
					ForeColor="White" Height="400px" Width="400px" 
					AccessKey="A" CssClass="wizard-class" style="margin:0 auto;"
					HeaderText="Header Text"
					>
					<HeaderTemplate>
						<h3>Templated Wizard - Header</h3>
					</HeaderTemplate>	
					<WizardSteps>
						<asp:WizardStep ID="WizardStep1">
							<p>Step 1</p>
						</asp:WizardStep>
					</WizardSteps>
				</ca:Wizard>

				<pre runat="server" id="adaptedMarkup"></pre>
				
			</div>
		</form>
	</body>
</html>
