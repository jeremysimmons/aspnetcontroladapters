<%@ Page Language="C#" AutoEventWireup="false" %>
<%@ Import Namespace="ControlAdapters.Renderers" %>

<script runat="server">
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		defaultMenu.Attributes["attrib1"] = "test1";
		adaptedMenu.Attributes["attrib1"] = "test1";

		MenuHtmlRenderer renderer = new MenuHtmlRenderer(adaptedMenu);
		adaptedMarkup.InnerHtml = Server.HtmlEncode(renderer.RenderBeginTag() + renderer.RenderContents() + renderer.RenderEndTag());
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Control Adapters: Menu</title>
	</head>
	<body>
		<form id="form1" runat="server">
			<div>
				<h1>ControlAdapters Menu Adapter Tests</h1>

				<h2>Markup Options</h2>
				
				<asp:Button runat="server" Text="Postback" />

				<hr />

				<h2>Default ASP.Net Markup</h2>

				<asp:Menu ID="defaultMenu" runat="server" 
					AccessKey="A" attrib2="test2" 
					BackColor="Red" BorderStyle="Solid" BorderColor="Green" BorderWidth="2" 
					ForeColor="Blue" Height="200px" Width="200px"
					CssClass="class" TabIndex="1">
					<Items>
						<asp:MenuItem Value="0" Text="Normal" ToolTip="ToolTip" />
						<asp:MenuItem Value="1" Text="Disabled" Enabled="false" />
						<asp:MenuItem Value="2" Text="Selected" Selected="true" />
						<asp:MenuItem Value="NoText" />
						<asp:MenuItem />
					</Items>
				</asp:Menu>

				<hr />

				<h2>Adapted ASP.Net Markup</h2>

				<ca:Menu ID="adaptedMenu" runat="server"
					AccessKey="B" attrib2="test2" 
					BackColor="Red" BorderStyle="Solid" BorderColor="Green" BorderWidth="2" 
					ForeColor="Blue" Height="200px" Width="200px"
					CssClass="class" TabIndex="11">
					<Items>
						<asp:MenuItem Value="0" Text="Normal" ToolTip="ToolTip" />
						<asp:MenuItem Value="1" Text="Disabled" Enabled="false" />
						<asp:MenuItem Value="2" Text="Selected" Selected="true" />
						<asp:MenuItem Value="NoText" />
						<asp:MenuItem />
					</Items>
				</ca:Menu>

				<pre runat="server" id="adaptedMarkup"></pre>
				
			</div>
		</form>
	</body>
</html>
