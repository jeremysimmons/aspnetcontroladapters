<%@ Page Language="C#" AutoEventWireup="false" %>
<%@ Import Namespace="ControlAdapters.Renderers" %>

<script runat="server">
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);

		defaultRadioButtonList.Attributes["attrib1"] = "test1";
		adaptedRadioButtonList.Attributes["attrib1"] = "test1";

		RepeatDirection rDir = (repeatDirectionOption.SelectedValue == "horizontal"
			? RepeatDirection.Horizontal : RepeatDirection.Vertical);
		RepeatLayout rLay = (repeatLayoutOption.SelectedValue == "table"
			? RepeatLayout.Table : RepeatLayout.Flow);
		
		defaultRadioButtonList.RepeatDirection = rDir;
		defaultRadioButtonList.RepeatLayout = rLay;
		defaultRadioButtonList.AutoPostBack = autoPostBackOption.Checked;
		
		adaptedRadioButtonList.RepeatDirection = rDir;
		adaptedRadioButtonList.RepeatLayout = rLay;
		adaptedRadioButtonList.AutoPostBack = autoPostBackOption.Checked;

		RadioButtonListHtmlRenderer renderer = new RadioButtonListHtmlRenderer(adaptedRadioButtonList);
		adaptedMarkup.InnerHtml = Server.HtmlEncode(renderer.RenderBeginTag() + renderer.RenderContents() + renderer.RenderEndTag());
	}
</script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>Control Adapters: RadioButtonList</title>
	</head>
	<body>
		<form id="form1" runat="server">
			<div>
				<h1>ControlAdapters RadioButtonList Adapter Tests</h1>

				<h2>Markup Options</h2>
				
				<asp:Button runat="server" Text="Postback" />
				
				<asp:RadioButton runat="server" ID="autoPostBackOption" AutoPostBack="true" Text="Auto Postback?" />
				
				<asp:DropDownList runat="server" ID="repeatDirectionOption" AutoPostBack="true">
					<asp:ListItem Value="vertical">Vertical</asp:ListItem>
					<asp:ListItem Value="horizontal">Horizontal</asp:ListItem>
				</asp:DropDownList>

				<asp:DropDownList runat="server" ID="repeatLayoutOption" AutoPostBack="true">
					<asp:ListItem Value="table">Table</asp:ListItem>
					<asp:ListItem Value="flow">Flow</asp:ListItem>
				</asp:DropDownList>

				<hr />

				<h2>Default ASP.Net Markup</h2>

				<asp:RadioButtonList ID="defaultRadioButtonList" runat="server" 
					AccessKey="A" attrib2="test2" 
					BackColor="Red" BorderStyle="Solid" BorderColor="Green" BorderWidth="2" 
					ForeColor="Blue" Height="200px" Width="200px"
					CssClass="class" TabIndex="1">
					<asp:ListItem Value="0">Normal</asp:ListItem>
					<asp:ListItem Value="1" Text="Disabled" Enabled="false" />
					<asp:ListItem Value="2" Text="Selected" Selected="True" />
					<asp:ListItem Value="NoText" />
					<asp:ListItem />
				</asp:RadioButtonList>

				<hr />

				<h2>Adapted ASP.Net Markup</h2>

				<ca:RadioButtonList ID="adaptedRadioButtonList" runat="server"
					AccessKey="B" attrib2="test2" 
					BackColor="Red" BorderStyle="Solid" BorderColor="Green" BorderWidth="2" 
					ForeColor="Blue" Height="200px" Width="200px"
					CssClass="class" TabIndex="11">
					<asp:ListItem Value="0">Normal</asp:ListItem>
					<asp:ListItem Value="1" Text="Disabled" Enabled="false" />
					<asp:ListItem Value="2" Text="Selected" Selected="True" />
					<asp:ListItem Value="NoText" />
					<asp:ListItem />
				</ca:RadioButtonList>

				<pre runat="server" id="adaptedMarkup"></pre>
				
			</div>
		</form>
	</body>
</html>
