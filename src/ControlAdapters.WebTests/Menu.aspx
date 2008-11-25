<%@ Page Language="C#" AutoEventWireup="false" %>
<%@ Import Namespace="ControlAdapters.Renderers" %>

<script runat="server">
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		defaultMenu.Attributes["attrib1"] = "test1";
		adaptedMenu.Attributes["attrib1"] = "test1";

		Orientation orientation = (orientationOption.SelectedValue == "horizontal" ? Orientation.Horizontal : Orientation.Vertical);
		defaultMenu.Orientation = orientation;
		adaptedMenu.Orientation = defaultMenu.Orientation;
		
		defaultMenu.StaticDisplayLevels = int.Parse(staticLevels.Text);
		adaptedMenu.StaticDisplayLevels = defaultMenu.StaticDisplayLevels;

		defaultMenu.MaximumDynamicDisplayLevels = int.Parse(dynamicLevels.Text);
		adaptedMenu.MaximumDynamicDisplayLevels = defaultMenu.MaximumDynamicDisplayLevels;

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
				
				<asp:DropDownList runat="server" ID="orientationOption">
					<asp:ListItem Value="vertical">Vertical</asp:ListItem>
					<asp:ListItem Value="horizontal">Horizontal</asp:ListItem>
				</asp:DropDownList>
				
				<asp:Label ID="Label1" runat="server" AssociatedControlID="staticLevels">StaticDisplayLevels</asp:Label>
				<asp:TextBox runat="server" ID="staticLevels" Columns="1" Text="2" />
				
				<asp:Label ID="Label2" runat="server" AssociatedControlID="dynamicLevels">MaximumDynamicDisplayLevels</asp:Label>
				<asp:TextBox runat="server" ID="dynamicLevels" Columns="2" Text="2" />
				
				<asp:Button runat="server" Text="Postback" />

				<hr />

				<h2>Default ASP.Net Markup</h2>

				<asp:Menu ID="defaultMenu" runat="server" 
					AccessKey="A" CssClass="class" TabIndex="1">
					<Items>
						<asp:MenuItem Text="File" Value="1" ToolTip="Perform a file operation">
							<asp:MenuItem Text="New" Value="11" ToolTip="Open a new document" />
							<asp:MenuItem Text="Open" Value="12" />
						</asp:MenuItem>
						<asp:MenuItem Text="Edit" Value="2">
							<asp:MenuItem Text="Copy" Value="21" Selectable="false" />
							<asp:MenuItem Text="Paste" Value="22" />
							<asp:MenuItem Text="Clear" Value="23" Enabled="false" />
						</asp:MenuItem>
						<asp:MenuItem Text="View" Value="3" Enabled="false">
							<asp:MenuItem Text="Normal" Value="31" />
							<asp:MenuItem Text="Preview" Value="32" />
						</asp:MenuItem>
						<asp:MenuItem Text="Help" Value="4">
							<asp:MenuItem Text="How To" Value="41" Selectable="false">
								<asp:MenuItem Text="Contents" Value="411" />
								<asp:MenuItem Text="Index" Value="412" />
								<asp:MenuItem Text="Search" Value="413" />
							</asp:MenuItem>
							<asp:MenuItem Text="About" Value="42" />
						</asp:MenuItem>
						<asp:MenuItem Value="NoText" />
						<asp:MenuItem />
					</Items>
				</asp:Menu>

				<hr />

				<h2>Adapted ASP.Net Markup</h2>

				<ca:Menu ID="adaptedMenu" runat="server"
					AccessKey="A" CssClass="class" TabIndex="1">
					<Items>
						<asp:MenuItem Text="File" Value="1" ToolTip="Perform a file operation">
							<asp:MenuItem Text="New" Value="11" ToolTip="Open a new document" />
							<asp:MenuItem Text="Open" Value="12" />
						</asp:MenuItem>
						<asp:MenuItem Text="Edit" Value="2">
							<asp:MenuItem Text="Copy" Value="21" Selectable="false" />
							<asp:MenuItem Text="Paste" Value="22" />
							<asp:MenuItem Text="Clear" Value="23" Enabled="false" />
						</asp:MenuItem>
						<asp:MenuItem Text="View" Value="3" Enabled="false">
							<asp:MenuItem Text="Normal" Value="31" />
							<asp:MenuItem Text="Preview" Value="32" />
						</asp:MenuItem>
						<asp:MenuItem Text="Help" Value="4">
							<asp:MenuItem Text="How To" Value="41" Selectable="false">
								<asp:MenuItem Text="Contents" Value="411" />
								<asp:MenuItem Text="Index" Value="412" />
								<asp:MenuItem Text="Search" Value="413" />
							</asp:MenuItem>
							<asp:MenuItem Text="About" Value="42" />
						</asp:MenuItem>
						<asp:MenuItem Value="NoText" />
						<asp:MenuItem />
					</Items>
				</ca:Menu>

				<pre runat="server" id="adaptedMarkup"></pre>
				
			</div>
		</form>
	</body>
</html>
