<%@ Page Language="C#" AutoEventWireup="false" %>
<%@ Import Namespace="ControlAdapters.Renderers" %>

<script runat="server">
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		RepeatDirection rDir = (repeatDirectionOption.SelectedValue == "horizontal"
			? RepeatDirection.Horizontal : RepeatDirection.Vertical);
		RepeatLayout rLay = (repeatLayoutOption.SelectedValue == "table"
			? RepeatLayout.Table : RepeatLayout.Flow);
		
		defaultCheckBoxList.RepeatDirection = rDir;
		defaultCheckBoxList.RepeatLayout = rLay;
		defaultCheckBoxList.AutoPostBack = autoPostBackOption.Checked;
		
		adaptedCheckBoxList.RepeatDirection = rDir;
		adaptedCheckBoxList.RepeatLayout = rLay;
		adaptedCheckBoxList.AutoPostBack = autoPostBackOption.Checked;

		CheckBoxListHtmlRenderer renderer = new CheckBoxListHtmlRenderer(adaptedCheckBoxList);
		adaptedMarkup.InnerHtml = Server.HtmlEncode(renderer.RenderBeginTag() + renderer.RenderContents() + renderer.RenderEndTag());
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Control Adapters: CheckBoxList</title>
	</head>
	<body>
		<form id="form1" runat="server">
			<div>
				<h1>ControlAdapters CheckBoxList Adapter Tests</h1>

				<h2>Markup Options</h2>
				
				<asp:CheckBox runat="server" ID="autoPostBackOption" Text="Auto Postback?" />
				
				<asp:DropDownList runat="server" ID="repeatDirectionOption">
					<asp:ListItem Value="vertical">Vertical</asp:ListItem>
					<asp:ListItem Value="horizontal">Horizontal</asp:ListItem>
				</asp:DropDownList>

				<asp:DropDownList runat="server" ID="repeatLayoutOption">
					<asp:ListItem Value="table">Table</asp:ListItem>
					<asp:ListItem Value="flow">Flow</asp:ListItem>
				</asp:DropDownList>

				<asp:Button ID="Button1" runat="server" Text="Update" />
				
				<hr />

				<h2>Default ASP.Net Markup</h2>

				<asp:CheckBoxList ID="defaultCheckBoxList" runat="server" 
					BackColor="Red" BorderStyle="Solid" BorderColor="Green" BorderWidth="2" 
					ForeColor="Blue" Height="200px" Width="200px"
					AccessKey="A" CssClass="class" TabIndex="1">
					<asp:ListItem Value="0">Normal</asp:ListItem>
					<asp:ListItem Value="1" Text="Disabled" Enabled="false" />
					<asp:ListItem Value="2" Text="Selected" Selected="True" />
					<asp:ListItem Value="NoText" />
					<asp:ListItem />
				</asp:CheckBoxList>

				<hr />

				<h2>Adapted ASP.Net Markup</h2>

				<ca:CheckBoxList ID="adaptedCheckBoxList" runat="server"
					BackColor="Red" BorderStyle="Solid" BorderColor="Green" BorderWidth="2" 
					ForeColor="Blue" Height="200px" Width="200px"
					AccessKey="A" CssClass="class" TabIndex="1">
					<asp:ListItem Value="0">Normal</asp:ListItem>
					<asp:ListItem Value="1" Text="Disabled" Enabled="false" />
					<asp:ListItem Value="2" Text="Selected" Selected="True" />
					<asp:ListItem Value="NoText" />
					<asp:ListItem />
				</ca:CheckBoxList>

				<pre runat="server" id="adaptedMarkup"></pre>
				
			</div>
		</form>
	</body>
</html>
